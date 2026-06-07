using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Debuff
{
    /// <summary>
    /// Hasar verir ve kritik hasar atma şansını azaltır
    /// </summary>
    public class Burn : Skill
    {
        public int Damage { get; private set; } // Verilen hasar
        public int CritChanceReduction { get; private set; } // Hedefin kritik hasar atma şansını azaltma miktarı
        public Burn() : base("Burn", "Causes the target to take damage and reduce critical hit chance", 3, 20, SkillType.Debuff, SkillName.Burn)
        {
            Damage = 6;
            CritChanceReduction = 7;
        }
    }
}