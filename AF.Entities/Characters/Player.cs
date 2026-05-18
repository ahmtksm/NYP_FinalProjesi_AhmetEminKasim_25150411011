using AF.Entities.Characters;
using AF.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters
{
    /// <summary>
    /// Represents the playable character controlled by the user.
    /// </summary>
    public class Player : Character
    {
        public Player(string name, int maxHealth, Stats stats) : base(name, maxHealth, stats) // Creates a new player character
        {

        }
    }
}
