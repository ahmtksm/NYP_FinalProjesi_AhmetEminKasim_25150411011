using AF.Business.Abstract;
using AF.Core.Results;
using AF.DataAccess;
using AF.DataAccess.Abstract;
using AF.Entities;
using AF.Entities.Characters.Enemies;
using AF.Entities.Characters.Players;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Managers
{
    /// <summary>
    /// Oyun durumunu kaydetme ve yükleme işlemlerini yönetir
    /// </summary>
    public class SaveManager : ISaveService
    {
        private readonly ISaveRepository _saveRepository;
        private readonly CharacterRepository _characterRepository;
        private readonly ItemRepository _itemRepository;
        private readonly SkillRepository _skillRepository;
        public SaveManager(ISaveRepository saveRepository, CharacterRepository characterRepository, ItemRepository itemRepository, SkillRepository skillRepository)
        {
            _saveRepository = saveRepository;
            _characterRepository = characterRepository;
            _itemRepository = itemRepository;
            _skillRepository = skillRepository;
        }

        /// <summary>
        /// Mevcut oyun durumunu bir dosyaya kaydeder
        /// </summary>
        public IResult Save(Player player, Enemy enemy) 
        {
            SaveData saveData = new SaveData
            {
                PlayerType = player.PlayerType,
                Health = player.Health,
                Mana = player.Stats.Mana,
                Inventory = player.Inventory.Select(i => i.ItemName).ToList(),
                Skills = player.Skills.Select(s => s.SkillName).ToList(),
                EnemyType = enemy.EnemyType,
                EnemyHealth = enemy.Health,
                EnemyMana = enemy.Stats.Mana
            };

            _saveRepository.SaveGame(saveData);
            return new Result(true, "Game saved successfully.", ResultType.Success);
        }

        /// <summary>
        /// Bir dosyadan oyun durumunu yükler ve oyuncu nesnesini döndürür
        /// </summary>
        public IDataResult<GameState> Load() 
        {
            // Kaydedilmiş bir oyun olup olmadığını kontrol eder
            if (!_saveRepository.SaveExists()) return new DataResult<GameState>(false, "No save file found.", null); 

            SaveData? saveData = _saveRepository.LoadGame();

            // Kaydedilmiş oyun verisi bulunamazsa uygun bir hata mesajı döndürür
            if (saveData == null) return new DataResult<GameState>(false, "No saved game found.", null);

            var playerData = _characterRepository.CreatePlayer(saveData.PlayerType);            
            if (!playerData.Success) return new DataResult<GameState>(false, playerData.Message, null); // Kaydedilmiş oyuncu türü geçersizse uygun bir hata mesajı döndürür            
            if (playerData.Data == null) return new DataResult<GameState>(false, "Player Data is null.", null); // Kaydedilmiş oyuncu verisi bulunamazsa uygun bir hata mesajı döndürür

            Player player = playerData.Data;
            player.Health = saveData.Health;
            player.Stats.Mana = saveData.Mana;
            player.Skills.Clear();
            player.Inventory.Clear();

            foreach (SkillName skillName in saveData.Skills)
            {
                var skillData = _skillRepository.CreateSkill(skillName);
                if (skillData.Success && skillData.Data != null) player.Skills.Add(skillData.Data);
            }
            foreach (ItemName itemName in saveData.Inventory)
            {
                var itemData = _itemRepository.CreateItem(itemName);
                if (itemData.Success && itemData.Data != null) player.Inventory.Add(itemData.Data);
            }

            var enemyData = _characterRepository.CreateEnemy(saveData.EnemyType);
            if (!enemyData.Success) return new DataResult<GameState>(false, enemyData.Message, null); // Kaydedilmiş düşman türü geçersizse uygun bir hata mesajı döndürür
            if (enemyData.Data == null) return new DataResult<GameState>(false, "Enemy Data is null.", null);// Kaydedilmiş düşman verisi bulunamazsa uygun bir hata mesajı döndürür

            Enemy enemy = enemyData.Data;
            enemy.Health = saveData.EnemyHealth;
            enemy.Stats.Mana = saveData.EnemyMana;

            GameState gameState = new GameState
            {
                Player = player,
                Enemy = enemy
            };

            return new DataResult<GameState>(true, "Game loaded successfully.", gameState);
        }   
    }
}