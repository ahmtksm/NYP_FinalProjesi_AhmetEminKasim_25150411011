using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Buff
{
    /// <summary>
    /// Offensive buff skill
    /// </summary>
    public class Rage : BuffSkill
    {
        public int DamageBoost { get; private set; } // Amount of damage increase
        public int Duration { get; private set; } // Duration of the buff in turns
        public Rage() : base("Rage", "Increases damage output for a short duration.", 4, 10) // Creates a new Rage skill
        {
            DamageBoost = 20;
            Duration = 3;
        }
    }
}
