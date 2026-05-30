using AF.Entities.Characters;
using AF.Entities.Enums;
using AF.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills
{
    /// <summary>
    /// Base class for all skills [EN]
    /// Tüm beceriler için temel sınıf [TR]
    /// </summary>
    public abstract class Skill : ISkill
    {
        public string Name { get; protected set; } // Name of the skill [EN] / Becerinin adı [TR]
        public string Description { get; protected set; } // Description of the skill's effect [EN] / Becerinin etkisinin açıklaması [TR]
        public int Cooldown { get; protected set; } // Cooldown time in turns [EN] / Tur cinsinden bekleme süresi [TR]
        public int RemainingCooldown { get; set; } // Remaining cooldown time in turns [EN] / Tur cinsinden kalan bekleme süresi [TR]
        public int ManaCost { get; protected set; } // Mana cost to use the skill  [EN] / Beceriyi kullanmak için gereken mana değeri [TR]
        public SkillType SkillType { get; protected set; } // Skill Category [EN] / Beceri Kategorisi [TR]
        public SkillName SkillName { get; protected set; } // Enum value for the skill name [EN] / Beceri adı için enum değeri [TR]
        protected Skill(string name, string description, int cooldown, int manaCost, SkillType skillType, SkillName skillName)
        {
            Name = name;
            Description = description;
            Cooldown = cooldown;
            ManaCost = manaCost;
            SkillType = skillType;
            SkillName = skillName;
            RemainingCooldown = 0;            
        }
    }
}