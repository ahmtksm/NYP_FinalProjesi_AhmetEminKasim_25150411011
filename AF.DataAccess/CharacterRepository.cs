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
    /// Bu depo, karakter türlerine göre oyuncu ve düşmanları oluşturmaktan sorumludur
    /// </summary>
    public class CharacterRepository
    {
        /// <summary>
        /// Bu metot, sağlanan karakter türüne ve adına göre bir oyuncu oluşturur
        /// </summary>
        public IDataResult<Player> CreatePlayer(PlayerType playerType)
        {
            Player player;
            switch (playerType)
            {
                case PlayerType.Assassin: player = new Assassin(); break;
                case PlayerType.Berserker: player = new Berserker(); break;
                case PlayerType.Knight: player = new Knight(); break;
                case PlayerType.Mage: player = new Mage(); break;
                case PlayerType.Necromancer: player = new Necromancer(); break;
                case PlayerType.Paladin: player = new Paladin(); break;
                case PlayerType.Ranger: player = new Ranger(); break;
                default: return new DataResult<Player>(false, "Invalid player type.", null);
            }
            return new DataResult<Player>(true, "Player created successfully.", player);
        }

        /// <summary>
        /// Bu metot, sağlanan düşman türüne ve adına göre bir düşman oluşturur
        /// </summary>
        public IDataResult<Enemy> CreateEnemy(EnemyType enemyType)
        {
            Enemy enemy;
            switch (enemyType)
            {
                case EnemyType.Goblin: enemy = new Goblin(); break;
                case EnemyType.Orc: enemy = new Orc(); break;
                case EnemyType.Skeleton: enemy = new Skeleton(); break;
                case EnemyType.DarkMage: enemy = new DarkMage(); break;
                case EnemyType.Demon: enemy = new Demon(); break;
                default: return new DataResult<Enemy>(false, "Invalid enemy type.", null);
            }
            return new DataResult<Enemy>(true, "Enemy created successfully.", enemy);
        }
    }
}