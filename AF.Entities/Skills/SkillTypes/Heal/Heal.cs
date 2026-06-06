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
    /// Hedefin sağlığını yenileyen beceri
    /// </summary>
    public class Heal : Skill
    {
        public int HealAmount { get; private set; } // Becerinin doldurduğu sağlık miktarı
        public Heal() : base("Heal", "Restores health to the target.", 3, 20, SkillType.Heal, SkillName.Heal)
        {
            HealAmount = 30;
        }
    }
}