using AF.Entities.Enums;
using AF.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters
{
    /// <summary>
    /// Base class for all playable and enemy characters [EN]
    /// Tüm oynanabilir ve düşman karakterleri için temel sınıf [TR]
    /// </summary>
    public abstract class Character
    {
        public string Name { get; protected set; } // Character's name [EN] / Karakterin adı [TR]
        public int Health { get; set; } // Current health points [EN] / Mevcut sağlık puanları [TR]
        public int MaxHealth { get; protected set; } // Maximum health points [EN] / Maksimum sağlık puanları [TR]
        public bool IsAlive => Health > 0; // Indicates if the character is alive [EN] / Karakterin hayatta olup olmadığını gösterir [TR]
        public bool IsDefending { get; set; } // Indicates if the character is defending [EN] / Karakterin savunma modunda olup olmadığını gösterir [TR]
        public Stats Stats { get; set; } // Character's stats [EN] / Karakterin istatistikleri [TR]
        public List<ISkill> Skills { get; protected set; } // List of skills the character can use [EN] / Karakterin kullanabileceği becerilerin listesi [TR]
        public List<IItem> Inventory { get; protected set; } // List of items the character has in their inventory [EN] / Karakterin envanterinde bulunan eşyaların listesi [TR]
        protected Character(string name, int maxHealth, Stats stats)
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