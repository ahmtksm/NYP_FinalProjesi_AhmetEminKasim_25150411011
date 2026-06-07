using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Debuff
{
    /// <summary>
    /// Rastgele hasar verir
    /// </summary>
    public class Poison : Skill
    {
        public Poison() : base("Poison", "Causes random damage to the target", 4, 15, SkillType.Debuff, SkillName.Poison)
        {

        }
    }
}