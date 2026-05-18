using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Damage
{
    /// <summary>
    /// Assassin attack skill with high critical chance
    /// </summary>
    public class Backstab : DamageSkill
    {
        public int Damage { get; private set; } // Base damage of the skill
        public int CritBonus { get; private set; } // Additional damage added on a critical hit
        public Backstab() : base("Back Stab", "Stabs an enemy from behind, dealing critical damage.", 2, 15) // Creats a new backstab skill
        {
            Damage = 25;
            CritBonus = 40;
        }
    }
}
