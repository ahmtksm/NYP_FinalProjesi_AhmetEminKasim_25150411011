using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Heal
{
    /// <summary>
    /// Skill that damages enemy and heals user
    /// </summary>
    public class LifeDrain : HealSkill
    {
        public int Damage { get; private set; } // Damage dealt to the target
        public int HealAmount { get; private set; } // Amount healed to the user
        public LifeDrain() : base("Life Drain", "Drains life from the enemy to heal the user.", 4, 25) // Creates a new Life Drain skill
        {
            Damage = HealAmount = 20;
        }
    }
}
