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
    /// Poison damage over time skill [EN]
    /// Zamanla hasar veren zehir becerisi [TR]
    /// </summary>
    public class Poison : Skill
    {
        public int Damage { get; private set; } // Damage dealt to the target each turn while poisoned [EN] / Zehirli olduğu sürece hedefe her turda verilen hasar [TR]
        public int Duration { get; private set; } // Duration in turns that the target will be poisoned [EN] / Hedefin zehirli kalacağı tur sayısı [TR]
        public Poison() : base("Poison", "Causes the target to take damage over time.", 4, 15, SkillType.Debuff, SkillName.Poison)
        {
            Damage = 8;
            Duration = 4;
        }
    }
}