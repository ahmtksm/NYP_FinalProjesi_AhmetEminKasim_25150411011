using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Damage
{
    /// <summary>
    /// Assassin attack skill with high critical chance [EN]
    /// Yüksek kritik şansı olan suikastçi saldırısı [TR]
    /// </summary>
    public class Backstab : Skill
    {
        public int Damage { get; private set; } // Base damage of the skill [EN] / Becerinin temel hasarı [TR]
        public int CritBonus { get; private set; } // Additional damage added on a critical hit [EN] / Kritik vuruşta eklenen ekstra hasar [TR]
        public Backstab() : base("Back Stab", "Stabs an enemy from behind, dealing critical damage.", 2, 15, SkillType.Damage, SkillName.Backstab)
        {
            Damage = 25;
            CritBonus = 40;
        }
    }
}