using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Debuff
{
    /// <summary>
    /// Ice skill that freezes the enemy
    /// </summary>
    public class Freeze : DebuffSkill
    {
        public int FreezeDuration { get; private set; } // Duration in turns that the target will be frozen
        public Freeze() : base("Freeze", "Temporarily immobilizes the target.", 5, 25) // Creates a new freeze skill
        {
            FreezeDuration = 1;
        }
    }
}
