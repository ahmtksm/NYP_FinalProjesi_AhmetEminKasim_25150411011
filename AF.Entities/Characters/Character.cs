using AF.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters
{
    /// <summary>
    /// Base class for all playable and enemy characters
    /// </summary>
    public abstract class Character
    {
        public string Name { get; protected set; } // Character's name
        public int Health { get; protected set; } // Current health points
        public int MaxHealth { get; protected set; } // Maximum health points
        public bool IsAlive => Health > 0; // Indicates if the character is alive
        public Stats Stats { get; protected set; } // Character's stats
        public List<ISkill> Skills { get; protected set; } // List of skills the character can use
        public List<IItem> Inventory { get; protected set; } // List of items the character has in their inventory
        protected Character(string name, int maxHealth, Stats stats) // Creates a new character
        {
            Name = name;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Stats = stats;
            Skills = new List<ISkill>();
            Inventory = new List<IItem>();
        }
    }
}
