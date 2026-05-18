using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Damage
{
    /// <summary>
    /// Powerful sword attack skill
    /// </summary>
    public class BloodSlash : DamageSkill
    {
        public int Damage { get; private set; } // Damage dealt to the target
        public int SelfDamage { get; private set; } // Damage taken by the user as a drawback
        public BloodSlash() : base("Blood Slash", "Slashes the enemy, dealing damage and taking some damage.", 4, 20) // Creates a new blood slash skill
        {
            Damage = 45;
            SelfDamage = 10;
        }
    }
}
