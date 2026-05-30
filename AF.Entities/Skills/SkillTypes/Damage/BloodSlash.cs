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
    /// Powerful sword attack skill [EN]
    /// Güçlü kılıç saldırısı [TR]
    /// </summary>
    public class BloodSlash : Skill
    {
        public int Damage { get; private set; } // Damage dealt to the target [EN] / Hedefe verilen hasar [TR]
        public int SelfDamage { get; private set; } // Damage taken by the user as a drawback [EN] / Kullanıcı tarafından alınan ekstra hasar [TR]
        public BloodSlash() : base("Blood Slash", "Slashes the enemy, dealing damage and taking some damage.", 4, 20, SkillType.Damage, SkillName.BloodSlash)
        {
            Damage = 45;
            SelfDamage = 10;
        }
    }
}