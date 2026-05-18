using AF.Core.Enums;
using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Interfaces
{
    /// <summary>
    /// Represents skill behavior
    /// </summary>
    public interface ISkill
    {
        string Name { get; } // Name of the skill
        string Description { get; } // Description of the skill's effect
        int Cooldown { get; } // Cooldown time in turns
        int ManaCost { get; } // Mana cost to use the skill
        SkillType SkillType { get; } // Skill Category
    }
}
