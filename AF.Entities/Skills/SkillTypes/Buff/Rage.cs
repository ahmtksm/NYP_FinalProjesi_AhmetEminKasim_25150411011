using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Buff
{
    /// <summary>
    /// Offensive buff skill [EN]
    /// Saldırı'yı güçlendirme becerisi [TR]
    /// </summary>
    public class Rage : Skill
    {
        public int DamageBoost { get; private set; } // Amount of damage increase [EN] / Hasar artış miktarı [TR]
        public int Duration { get; private set; } // Duration of the buff in turns [EN] / Güçlenme'nin tur cinsinden süresi [TR]
        public Rage() : base("Rage", "Increases damage output for a short duration.", 4, 10, SkillType.Buff, SkillName.Rage)
        {
            DamageBoost = 20;
            Duration = 3;
        }
    }
}