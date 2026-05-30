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
    /// Ice skill that freezes the enemy [EN]
    /// Düşmanı geçici olarak dondurur [TR]
    /// </summary>
    public class Freeze : Skill
    {
        public int FreezeDuration { get; private set; } // Duration in turns that the target will be frozen [EN] / Hedefin kaç tur boyunca donacağını belirten süre [TR]
        public int SpeedReduction { get; private set; } // Amount of speed reduction applied to the target while frozen [EN] / Hedef donarken uygulanan hız azaltma miktarı [TR]

        public Freeze() : base("Freeze", "Temporarily immobilizes the target.", 5, 25, SkillType.Debuff, SkillName.Freeze)
        {
            FreezeDuration = 1;
            SpeedReduction = 5;
        }
    }
}