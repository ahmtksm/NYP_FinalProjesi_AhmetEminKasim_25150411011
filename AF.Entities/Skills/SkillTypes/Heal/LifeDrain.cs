using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Heal
{
    /// <summary>
    /// Skill that damages enemy and heals user [EN]
    /// Düşmana hasar verip kullanıcıyı iyileştiren beceri [TR]
    /// </summary>
    public class LifeDrain : Skill
    {
        public int Damage { get; private set; } // Damage dealt to the target [EN] / Hedefe verilen hasar [TR]
        public int HealAmount { get; private set; } // Amount healed to the user [EN] / Kullanıcıya verilen sağlık miktarı [TR]
        public LifeDrain() : base("Life Drain", "Drains life from the enemy to heal the user.", 4, 25, SkillType.Heal, SkillName.LifeDrain)
        {
            Damage = HealAmount = 20;
        }
    }
}