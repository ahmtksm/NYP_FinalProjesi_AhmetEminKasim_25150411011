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
    /// Damage over time fire skill [EN]
    /// Zamanla hasar veren yanma becerisi [TR]
    /// </summary>
    public class Burn : Skill
    {
        public int Damage { get; private set; } // Damage dealt each turn [EN] / Her turda verilen hasar [TR]
        public int Duration { get; private set; } // Number of turns the burn effect lasts [EN] / Yanma efektinin süresi [TR]
        public Burn() : base("Burn", "Causes the target to take damage over time.", 3, 20, SkillType.Debuff, SkillName.Burn)
        {
            Damage = 10;
            Duration = 3;
        }
    }
}