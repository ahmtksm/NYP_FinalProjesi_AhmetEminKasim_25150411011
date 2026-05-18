using AF.Entities.Characters;
using AF.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes
{
    /// <summary>
    /// a class representing damage skills
    /// </summary>
    public abstract class DamageSkill : Skill
    {
        public DamageSkill(string name, string description, int cooldown, int manaCost) : base(name, description, cooldown, manaCost, SkillType.Damage)
        {

        }
    }
}
