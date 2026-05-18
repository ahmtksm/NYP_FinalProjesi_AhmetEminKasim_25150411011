using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters
{
    /// <summary>
    /// Represents an enemy character controlled by the game's AI.
    /// </summary>
    public class Enemy : Character
    {
        public Enemy(string name, int maxHealth, Stats stats) : base(name, maxHealth, stats) // Creates a new enemy character
        {

        }
    }
}
