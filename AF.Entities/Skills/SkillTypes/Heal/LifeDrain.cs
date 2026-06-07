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
    /// Düşmana hasar verip kullanıcıyı iyileştiren beceri
    /// </summary>
    public class LifeDrain : Skill
    {
        public int HealTaken { get; private set; } // Hedeften çalınan sağlık miktarı
        public LifeDrain() : base("Life Drain", "Drains life from the enemy to heal the user", 4, 25, SkillType.Heal, SkillName.LifeDrain)
        {
            HealTaken = 20;
        }
    }
}