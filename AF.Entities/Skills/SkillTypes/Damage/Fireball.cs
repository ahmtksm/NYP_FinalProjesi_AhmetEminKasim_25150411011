using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Damage
{
    /// <summary>
    /// Offensive fire magic skill
    /// </summary>
    public class Fireball : DamageSkill
    {
        public int Damage { get; private set; } // Base damage of the fireball
        public int BurnChance { get; private set; } // Chance to inflict burn status effect (percentage)
        public Fireball() : base("Fireball", "Launches a fireball at the enemy, dealing damage and potentially causing a burn.", 3, 25) // Creates a new fireball skill
        {
            Damage = 35;
            BurnChance = 50;
        }
    }
}
