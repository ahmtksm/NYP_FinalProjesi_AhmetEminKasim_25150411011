using AF.Core.Results;
using AF.Entities.Enums;
using AF.Entities.Characters.Enemies;
using AF.Entities.Characters.Enemies.EnemyTypes;
using AF.Entities.Characters.Players;
using AF.Entities.Characters.Players.PlayerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DataAccess
{
    /// <summary>
    /// This repository is responsible for creating player and enemy instances based on their types [EN]
    /// Bu depo, karakter türlerine göre oyuncu ve düşmanları oluşturmaktan sorumludur [TR]
    /// </summary>
    public class CharacterRepository
    {
        // this method creates a player instance based on the provided player type and name [EN]
        // bu metot, sağlanan karakter türüne ve adına göre bir oyuncu oluşturur [TR]
        public IDataResult<Player> CreatePlayer(PlayerType playerType, string playerName)
        {
            Player player;
            switch (playerType)
            {
                case PlayerType.Assassin: player = new Assassin(playerName); break;
                case PlayerType.Berserker: player = new Berserker(playerName); break;
                case PlayerType.Knight: player = new Knight(playerName); break;
                case PlayerType.Mage: player = new Mage(playerName); break;
                case PlayerType.Necromancer: player = new Necromancer(playerName); break;
                case PlayerType.Paladin: player = new Paladin(playerName); break;
                case PlayerType.Ranger: player = new Ranger(playerName); break;
                default: return new DataResult<Player>(false, "Invalid player type.", null);
            }
            return new DataResult<Player>(true, "Player created successfully.", player);
        }
        // this method creates an enemy instance based on the provided enemy type and name [EN]
        // bu metot, sağlanan düşman türüne ve adına göre bir düşman oluşturur [TR]
        public IDataResult<Enemy> CreateEnemy(EnemyType enemyType, string enemyName)
        {
            Enemy enemy;
            switch (enemyType)
            {
                case EnemyType.Goblin: enemy = new Goblin(enemyName); break;
                case EnemyType.Orc: enemy = new Orc(enemyName); break;
                case EnemyType.Skeleton: enemy = new Skeleton(enemyName); break;
                case EnemyType.DarkMage: enemy = new DarkMage(enemyName); break;
                case EnemyType.Demon: enemy = new Demon(enemyName); break;
                default: return new DataResult<Enemy>(false, "Invalid enemy type.", null);
            }
            return new DataResult<Enemy>(true, "Enemy created successfully.", enemy);
        }
        // this method retrieves all available player types [EN]
        // bu metot, mevcut tüm karakter türlerini listeler [TR]
        public List<PlayerType> GetAllPlayerTypes()
        {
            return Enum.GetValues(typeof(PlayerType)).Cast<PlayerType>().ToList();
        }
        // this method retrieves all available enemy types [EN]
        // bu metot, mevcut tüm düşman türlerini listeler [TR]
        public List<EnemyType> GetAllEnemyTypes()
        {
            return Enum.GetValues(typeof(EnemyType)).Cast<EnemyType>().ToList();
        }
    }
}