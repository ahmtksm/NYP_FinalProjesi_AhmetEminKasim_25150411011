using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities
{
    /// <summary>
    /// Stores combat statistics of a character [EN]
    /// Karakterin savaş istatistiklerini tutar [TR]
    /// </summary>
    public class Stats
    {
        public int Damage { get; set; } // Base damage value [EN] / Temel hasar değeri [TR]
        public int Defense { get; set; } // Base defense value [EN] / Temel savunma değeri [TR]
        public int CritChance { get; set; } // Chance to land a critical hit [EN] / Kritik vuruş yapma şansı [TR]
        public int DodgeChance { get; set; } // Chance to dodge an attack [EN] / Bir saldırıyı savuşturma şansı [TR]
        public int Speed { get; set; } // Movement speed and attack speed [EN] / Hareket hızı ve saldırı hızı [TR]
        public int Mana { get; set; } // Mana value used for skills [EN] / Yetenekler için kullanılan mana değeri [TR]
        public Stats(int damage, int defense, int critChance, int dodgeChance, int speed, int mana)
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