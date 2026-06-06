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
    /// Tüm oynanabilir ve düşman karakterleri temsil eder
    /// </summary>
    public abstract class Character
    {
        public string Name { get; protected set; } // Karakterin adı
        public int Health { get; set; } // Mevcut sağlık
        public int MaxHealth { get; protected set; } // Maksimum sağlık
        public bool IsAlive => Health > 0; // Karakterin hayatta olup olmadığını gösterir
        public bool IsDefending { get; set; } // Karakterin savunma modunda olup olmadığını gösterir
        public Stats Stats { get; set; } // Karakterin istatistikleri
        public List<ISkill> Skills { get; protected set; } // Karakterin kullanabileceği becerilerin listesi
        public List<IItem> Inventory { get; protected set; } // Karakterin envanterinde bulunan eşyaların listesi
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