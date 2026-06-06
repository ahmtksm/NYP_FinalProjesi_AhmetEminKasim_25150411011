using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities
{
    /// <summary>
    /// Karakterin savaş istatistiklerini tutar
    /// </summary>
    public class Stats
    {
        public int Damage { get; set; } // Temel hasar değeri
        public int Defense { get; set; } // Temel savunma değeri
        public int CritChance { get; set; } // Kritik vuruş yapma şansı
        public int DodgeChance { get; set; } // Bir saldırıyı savuşturma şansı
        public int Mana { get; set; } // Yetenekler için kullanılan mana değeri
        public Stats(int damage, int defense, int critChance, int dodgeChance, int mana)
        {
            Damage = damage;
            Defense = defense;
            CritChance = critChance;
            DodgeChance = dodgeChance;
            Mana = mana;
        }
    }
}