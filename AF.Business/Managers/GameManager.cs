using AF.Business.Abstract;
using AF.Core.Results;
using AF.DataAccess;
using AF.Entities;
using AF.Entities.Abstract;
using AF.Entities.Characters;
using AF.Entities.Characters.Enemies;
using AF.Entities.Characters.Players;
using AF.Entities.Enums;
using AF.Entities.Items;
using AF.Entities.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Managers
{
    /// <summary>
    /// Oyunun genel akışını yönetir, savaşlar, kaydetme/yükleme, oyuncu eylemleri ve düşman turları vs.
    /// </summary>
    public class GameManager : IGameService
    {
        private readonly ICombatService _combatManager; // Saldırı ve savunma eylemlerini yönetir
        private readonly IEnemyAIService _enemyAIManager; // Düşmanların eylem seçimlerini yönetir
        private readonly IItemService _itemManager; // Eşyaların kullanımını yönetir
        private readonly ISaveService _saveManager; // Oyun durumunu kaydetme ve yükleme işlemlerini yönetir
        private readonly ISkillService _skillManager; // Becerilerin kullanımını ve bekleme sürelerini yönetir
        private readonly CharacterRepository _characterRepository; // Oyuncu ve düşman karakterlerini oluşturmak için veri erişim katmanı
        public GameManager(ICombatService combatManager, IEnemyAIService enemyAIManager, IItemService itemManager,
                           ISaveService saveManager, ISkillService skillManager, CharacterRepository characterRepository)
        {
            _combatManager = combatManager;
            _enemyAIManager = enemyAIManager;
            _itemManager = itemManager;
            _saveManager = saveManager;
            _skillManager = skillManager;
            _characterRepository = characterRepository;
        }

        /// <summary>
        /// Oyuncu sınıfına göre yeni bir oyuncu oluşturur
        /// </summary>
        public IDataResult<Player> NewGame(PlayerType playerType)
        {
            return _characterRepository.CreatePlayer(playerType);
        }

        /// <summary>
        /// Kaydedilmiş bir oyunu yükler
        /// </summary>
        public IDataResult<GameState> LoadGame()
        {
            return _saveManager.Load();
        }

        /// <summary>
        /// Rastgele bir düşman oluşturur
        /// </summary>
        public IDataResult<Enemy> GenerateRandomEnemy()
        {
            List<EnemyType> enemyTypes = Enum.GetValues(typeof(EnemyType)).Cast<EnemyType>().ToList(); // Düşmanların listesi
            EnemyType randomType = enemyTypes[Random.Shared.Next(enemyTypes.Count)]; // Listeden rastgele bir düşman seçer

            return _characterRepository.CreateEnemy(randomType);
        }

        /// <summary>
        /// Mevcut oyun durumunu kaydeder
        /// </summary>
        public IResult SaveGame(Player player, Enemy enemy)
        {
            return _saveManager.Save(player, enemy);
        }

        /// <summary>
        /// Oyuncunun seçtiği eylemi işler ve o eylemin sonucunu döner
        /// </summary>
        public IResult ProcessPlayerAction(ActionType action, Player player, Enemy enemy, ISkill? skill, IItem? item)
        {
            switch (action)
            {
                case ActionType.Attack:
                    return _combatManager.Attack(player, enemy);
                case ActionType.Defense:
                    return _combatManager.Defend(player);
                case ActionType.Skill:
                    if (skill == null) return new Result(false, "No Skill Selected.", ResultType.Error);
                    return _skillManager.UseSkill(player, enemy, skill);
                case ActionType.UseItem:
                    if (item == null) return new Result(false, "No Item Selected.", ResultType.Error);
                    if (item.ItemType == ItemType.Damage) return _itemManager.UseItem(player, enemy, item);
                    else return _itemManager.UseItem(player, player, item);
                default:
                    return new Result(false, "Invalid action.", ResultType.Error);
            }
        }

        /// <summary>
        /// Düşmanın AI kararına göre eylemini işler ve o eylemin sonucunu döner
        /// </summary>
        public IResult ProcessEnemyAction(Player player, Enemy enemy)
        {
            ActionType action = _enemyAIManager.ChooseAction(enemy);
            switch (action)
            {
                case ActionType.Attack:
                    return _combatManager.Attack(enemy, player);
                case ActionType.Defense:
                    return _combatManager.Defend(enemy);
                case ActionType.Skill:
                    ISkill? skill = _enemyAIManager.ChooseSkill(enemy);
                    if (skill == null) return new Result(false, "No Skill Selected.", ResultType.Error);
                    return _skillManager.UseSkill(enemy, player, skill);
                case ActionType.UseItem:
                    IItem? item = _enemyAIManager.ChooseItem(enemy);
                    if (item == null) return new Result(false, "No Item Selected.", ResultType.Error);
                    if (item.ItemType == ItemType.Damage) return _itemManager.UseItem(enemy, player, item);
                    else return _itemManager.UseItem(enemy, enemy, item);
                default: 
                    return new Result(false, "Enemy Skipped Its Turn.", ResultType.Error);
            }
        }

        /// <summary>
        /// Her turun sonunda tüm becerilerin bekleme sürelerini azaltır
        /// </summary>
        public IResult EndTurn(Character character)
        {
            return _skillManager.ReduceCooldowns(character);
        }

        /// <summary>
        /// Oyuncu veya düşmanın yenilip yenilmediğine göre oyunun bitip bitmediğini kontrol eder
        /// </summary>
        public bool IsBattleOver(Player player, Enemy enemy)
        {
            return !player.IsAlive || !enemy.IsAlive;
        }
    }
}