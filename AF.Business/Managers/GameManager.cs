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
        private readonly CombatManager _combatManager;
        private readonly EnemyAIManager _enemyAIManager;
        private readonly ItemManager _itemManager;
        private readonly SaveManager _saveManager;
        private readonly SkillManager _skillManager;
        private readonly CharacterRepository _characterRepository;
        private readonly Random _random = new Random(); // Rastgele düşman oluşturmak için
        public GameManager(CombatManager combatManager, EnemyAIManager enemyAIManager, ItemManager itemManager,
                           SaveManager saveManager, SkillManager skillManager, CharacterRepository characterRepository)
        {
            _combatManager = combatManager;
            _enemyAIManager = enemyAIManager;
            _itemManager = itemManager;
            _saveManager = saveManager;
            _skillManager = skillManager;
            _characterRepository = characterRepository;
        }

        // Oyuncu sınıfı ve ismine göre yeni bir oyuncu oluşturur
        public IDataResult<Player> NewGame(PlayerType playerType, string playerName) 
        {
            return _characterRepository.CreatePlayer(playerType, playerName);
        }

        // Kaydedilmiş bir oyunu yükler
        public IDataResult<GameState> LoadGame() 
        {
            return _saveManager.Load();
        }

        // Seçilen düşman türüne göre yeni bir düşman oluşturur
        public IDataResult<Enemy> GenerateEnemy(EnemyType enemyType, string enemyName) 
        {
            return _characterRepository.CreateEnemy(enemyType, enemyName);
        }

        // Rastgele bir düşman oluşturur
        public IDataResult<Enemy> GenerateRandomEnemy() 
        {
            List<EnemyType> enemyTypes = _characterRepository.GetAllEnemyTypes();
            EnemyType randomType = enemyTypes[_random.Next(enemyTypes.Count)];
            string enemyName = randomType.ToString();
            return _characterRepository.CreateEnemy(randomType, enemyName);
        }

        // Mevcut oyun durumunu kaydeder
        public IResult SaveGame(Player player, Enemy enemy) 
        {
            return _saveManager.Save(player, enemy);
        }

        // Oyuncunun seçtiği eylemi işler ve o eylemin sonucunu döner
        public IResult ProcessPlayerAction(ActionType action, Player player, Enemy enemy, ISkill? skill, IItem? item)
        {
            switch (action)
            {
                case ActionType.Attack: return _combatManager.Attack(player, enemy);
                case ActionType.Defense: return _combatManager.Defend(player);
                case ActionType.Skill:
                    if (skill == null) return new Result(false, "No Skill Selected.", ResultType.Error);
                    return _skillManager.UseSkill(player, enemy, skill);
                case ActionType.UseItem:
                    if (item == null) return new Result(false, "No Item Selected.", ResultType.Error);
                    return _itemManager.UseItem(player, player, item);
                default: return new Result(false, "Invalid action.", ResultType.Error);
            }
        }

        // Düşmanın AI kararına göre eylemini işler ve o eylemin sonucunu döner
        public IResult ProcessEnemyAction(Player player, Enemy enemy)
        {
            ActionType action = _enemyAIManager.ChooseAction(enemy);
            switch (action)
            {
                case ActionType.Attack: return _combatManager.Attack(enemy, player);
                case ActionType.Defense: return _combatManager.Defend(enemy);
                case ActionType.Skill:
                    ISkill? skill = _enemyAIManager.ChooseSkill(enemy);
                    if (skill == null) return new Result(false, "No Skill Selected.", ResultType.Error);
                    return _skillManager.UseSkill(enemy, player, skill);
                case ActionType.UseItem:
                    IItem? item = _enemyAIManager.ChooseItem(enemy);
                    if (item == null) return new Result(false, "No Item Selected.", ResultType.Error);
                    return _itemManager.UseItem(enemy, enemy, item);
                default: return new Result(false, "Enemy Skipped Its Turn.", ResultType.Error);
            }
        }

        // Her turun sonunda tüm becerilerin bekleme sürelerini azaltır
        public IResult EndTurn(Character character) 
        {
            return _skillManager.ReduceCooldowns(character);
        }

        // Oyuncu veya düşmanın yenilip yenilmediğine göre oyunun bitip bitmediğini kontrol eder
        public bool IsBattleOver(Player player, Enemy enemy) 
        {
            return !player.IsAlive || !enemy.IsAlive;
        }
    }
}