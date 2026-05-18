using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities
{
    /// <summary>
    /// Stores combat statistics of a character.
    /// </summary>
    public struct Stats
    {
        public int Damage { get; set; } // Base damage value
        public int Defense { get; set; } // Base defense value
        public int CritChance { get; set; } // Chance to land a critical hit
        public int DodgeChance { get; set; } // Chance to dodge an attack
        public int Speed { get; set; } // Movement speed
        public int Mana { get; set; } // Mana value used for skills
        public Stats(int damage, int defense, int critChance, int dodgeChance, int speed, int mana) // Constructor to initialize all stats
        {
            Damage = damage;
            Defense = defense;
            CritChance = critChance;
            DodgeChance = dodgeChance;
            Speed = speed;
            Mana = mana;
        }
    }
}
