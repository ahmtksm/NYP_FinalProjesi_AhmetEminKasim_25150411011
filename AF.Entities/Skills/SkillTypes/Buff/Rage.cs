using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Buff
{
    /// <summary>
    /// Saldırı'yı güçlendiren beceri
    /// </summary>
    public class Rage : Skill
    {
        public int DamageBoost { get; private set; } // Hasar artış miktarı
        public Rage() : base("Rage", "Increases damage output for a short duration.", 4, 10, SkillType.Buff, SkillName.Rage)
        {
            DamageBoost = 20;
        }
    }
}