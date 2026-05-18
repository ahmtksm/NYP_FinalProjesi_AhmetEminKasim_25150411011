using AF.Core.Enums;
using AF.Entities.Characters;
using AF.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills
{
    /// <summary>
    /// Base class for all skills
    /// </summary>
    public abstract class Skill : ISkill
    {
        public string Name { get; protected set; } // Name of the skill
        public string Description { get; protected set; } // Description of the skill's effect
        public int Cooldown { get; protected set; } // Cooldown time in turns
        public int RemainingCooldown { get; set; } // Remaining cooldown time in turns
        public int ManaCost { get; protected set; } // Mana cost to use the skill
        public SkillType SkillType { get; protected set; } // Skill Category
        protected Skill(string name, string description, int cooldown, int manaCost, SkillType skillType) // Creates a new skill
        {
            Name = name;
            Description = description;
            Cooldown = cooldown;
            ManaCost = manaCost;
            SkillType = skillType;
            RemainingCooldown = 0;
        }
    }
}
