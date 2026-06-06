using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Damage
{
    /// <summary>
    /// Hedefe yüksek hasar verir, ancak kullanıcıya da ekstra hasar verir.
    /// </summary>
    public class BloodSlash : Skill
    {
        public int Damage { get; private set; } // Hedefe verilen hasar
        public int SelfDamage { get; private set; } // Kullanıcı tarafından alınan ekstra hasar
        public BloodSlash() : base("Blood Slash", "Slashes the enemy, dealing damage and taking some damage.", 4, 20, SkillType.Damage, SkillName.BloodSlash)
        {
            Damage = 45;
            SelfDamage = 10;
        }
    }
}