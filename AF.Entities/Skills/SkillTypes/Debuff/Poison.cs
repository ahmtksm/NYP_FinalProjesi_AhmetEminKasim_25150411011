using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Debuff
{
    /// <summary>
    /// Poison damage over time skill
    /// </summary>
    public class Poison : DebuffSkill
    {
        public int PoisonDamage { get; private set; } // Damage dealt to the target each turn while poisoned
        public int Duration { get; private set; } // Duration in turns that the target will be poisoned
        public Poison() : base("Poison", "Causes the target to take damage over time.", 4, 15) // Creates a new poison skill
        {
            PoisonDamage = 8;
            Duration = 4;
        }
    }
}
