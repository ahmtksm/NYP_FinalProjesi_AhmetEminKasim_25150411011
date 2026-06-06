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
    /// Yüksek kritik şansı olan suikastçi saldırısı
    /// </summary>
    public class Backstab : Skill
    {
        public int Damage { get; private set; } // Becerinin temel hasarı
        public int CritBonus { get; private set; } // Kritik vuruşta eklenen ekstra hasar
        public Backstab() : base("Back Stab", "Stabs an enemy from behind, dealing critical damage.", 2, 15, SkillType.Damage, SkillName.Backstab)
        {
            Damage = 25;
            CritBonus = 40;
        }
    }
}