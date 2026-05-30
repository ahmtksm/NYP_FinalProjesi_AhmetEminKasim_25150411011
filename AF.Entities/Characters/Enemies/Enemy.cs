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
        public Enemy(string name, int maxHealth, Stats stats) : base(name, maxHealth, stats)
        {

        }
    }
}