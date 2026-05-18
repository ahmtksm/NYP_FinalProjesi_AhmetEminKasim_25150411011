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
    /// a class representing a healing skill
    /// </summary>
    public abstract class HealSkill : Skill
    {
        public HealSkill(string name, string description, int cooldown, int manaCost) : base(name, description, cooldown, manaCost, SkillType.Heal)
        {

        }
    }
}
