using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Enemies
{
    /// <summary>
    /// Düşman karakterini temsil eder
    /// </summary>
    public class Enemy : Character
    {
        public EnemyType EnemyType { get; protected set; } // Düşman türü (Goblin, Demon vs.)
        public Enemy(string name, int maxHealth, Stats stats, EnemyType enemyType) : base(name, maxHealth, stats)
        {
            EnemyType = enemyType;
        }
    }
}