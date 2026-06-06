using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Enemies
{
    /// <summary>
    /// Represents an enemy character controlled by the game's AI [EN]
    /// Düşman karakterini temsil eder [TR]
    /// </summary>
    public class Enemy : Character
    {
        public EnemyType EnemyType { get; protected set; } // Type of enemy (e.g., Goblin, Dragon) [EN] / Düşman türü (örneğin, Goblin, Dragon) [TR]
        public Enemy(string name, int maxHealth, Stats stats, EnemyType enemyType) : base(name, maxHealth, stats)
        {
            EnemyType = enemyType;
        }
    }
}