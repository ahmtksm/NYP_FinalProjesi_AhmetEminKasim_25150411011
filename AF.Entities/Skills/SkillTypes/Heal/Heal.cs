using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Heal
{
    /// <summary>
    /// Heal skill that restores health to the target [EN]
    /// Hedefin sağlığını yenileyen beceri [TR]
    /// </summary>
    public class Heal : Skill
    {
        public int HealAmount { get; private set; } // Amount of health restored by the skill [EN] / Becerinin doldurduğu sağlık miktarı [TR]
        public Heal() : base("Heal", "Restores health to the target.", 3, 20, SkillType.Heal, SkillName.Heal)
        {
            HealAmount = 35;
        }
    }
}