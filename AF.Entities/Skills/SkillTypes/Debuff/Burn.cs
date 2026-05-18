using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Debuff
{
    /// <summary>
    /// Damage over time fire skill
    /// </summary>
    public class Burn : DebuffSkill
    {
        public int BurnDamage { get; private set; } // Damage dealt each turn
        public int Duration { get; private set; } // Number of turns the burn effect lasts
        public Burn() : base("Burn", "Causes the target to take damage over time.", 3, 20) // Creates a new burn skill
        {
            BurnDamage = 10;
            Duration = 3;
        }
    }
}
