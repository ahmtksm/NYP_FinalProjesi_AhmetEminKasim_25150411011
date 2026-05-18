using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Heal
{
    public class Heal : HealSkill
    {
        public int HealAmount { get; private set; } // Amount of health restored by the skill
        public Heal() : base("Heal", "Restores health to the target.", 3, 20) // Creates a new heal skill
        {
            HealAmount = 35;
        }
    }
}
