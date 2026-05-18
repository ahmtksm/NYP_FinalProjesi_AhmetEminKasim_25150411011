using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Buff
{
    /// <summary>
    /// Defensive buff skill
    /// </summary>
    public class Shield : BuffSkill
    {
        public int DefenseBoost { get; private set; } // Amount of defense increase
        public int Duration { get; private set; } // Duration of the buff in turns
        public Shield() : base("Shield", "Provides temporary damage reduction.", 5, 10) // Create a new shield skill
        {
            DefenseBoost = 15;
            Duration = 3;
        }
    }
}
