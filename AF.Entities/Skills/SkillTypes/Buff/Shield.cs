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
    /// Savunma'yı arttıran beceri
    /// </summary>
    public class Shield : Skill
    {
        public int DefenseBoost { get; private set; } // Savunma artış miktarı
        public Shield() : base("Shield", "Provides damage reduction.", 5, 10, SkillType.Buff, SkillName.Shield)
        {
            DefenseBoost = 10;
        }
    }
}