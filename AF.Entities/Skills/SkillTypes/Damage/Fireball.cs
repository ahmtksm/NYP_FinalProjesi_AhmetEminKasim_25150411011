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
    /// Yanma efekti uygulayan saldırı becerisi
    /// </summary>
    public class Fireball : Skill
    {
        public int Damage { get; private set; } // Ateş topunun temel hasarı
        public int BurnChance { get; private set; } // Yanma efekti uygulama şansı
        public Fireball() : base("Fireball", "Launches a fireball, dealing damage and possibly burns the enemy", 3, 25, SkillType.Damage, SkillName.Fireball)
        {
            Damage = 35;
            BurnChance = 50;
        }
    }
}