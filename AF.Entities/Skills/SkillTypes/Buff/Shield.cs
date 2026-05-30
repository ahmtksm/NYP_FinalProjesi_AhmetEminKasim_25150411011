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
    /// Defensive buff skill [EN]
    /// Savunma'yı güçlendirme becerisi [TR]
    /// </summary>
    public class Shield : Skill
    {
        public int DefenseBoost { get; private set; } // Amount of defense increase [EN] / Savunma artış miktarı [TR]
        public int Duration { get; private set; } // Duration of the buff [EN] / Güçlenme'nin süresi [TR]
        public Shield() : base("Shield", "Provides temporary damage reduction.", 5, 10, SkillType.Buff, SkillName.Shield)
        {
            DefenseBoost = 15;
            Duration = 3;
        }
    }
}