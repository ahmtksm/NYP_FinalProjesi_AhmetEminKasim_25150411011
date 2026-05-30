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
    /// Offensive fire magic skill [EN]
    /// Yanma efekti uygulayan saldırı becerisi [TR]
    /// </summary>
    public class Fireball : Skill
    {
        public int Damage { get; private set; } // Base damage of the fireball [EN] / Ateş topunun temel hasarı [TR]
        public int BurnChance { get; private set; } // Chance to inflict burn status effect (percentage) [EN] / Yanma efekti uygulama şansı (yüzde) [TR]
        public Fireball() : base("Fireball", "Launches a fireball at the enemy, dealing damage and potentially causing a burn.", 3, 25, SkillType.Damage, SkillName.Fireball)
        {
            Damage = 35;
            BurnChance = 50;
        }
    }
}