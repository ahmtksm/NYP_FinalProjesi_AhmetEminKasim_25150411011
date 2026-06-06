using AF.Entities.Characters;
using AF.Entities.Enums;
using AF.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills
{
    /// <summary>
    /// Tüm beceriler için temel sınıf
    /// </summary>
    public abstract class Skill : ISkill
    {
        public string Name { get; protected set; } // Becerinin adı
        public string Description { get; protected set; } // Becerinin etkisinin açıklaması
        public int Cooldown { get; protected set; } // Tur cinsinden bekleme süresi
        public int RemainingCooldown { get; set; } // Tur cinsinden kalan bekleme süresi
        public int ManaCost { get; protected set; } // Beceriyi kullanmak için gereken mana değeri
        public SkillType SkillType { get; protected set; } // Beceri Kategorisi
        public SkillName SkillName { get; protected set; } // Beceri adı için enum değeri
        protected Skill(string name, string description, int cooldown, int manaCost, SkillType skillType, SkillName skillName)
        {
            Name = name;
            Description = description;
            Cooldown = cooldown;
            ManaCost = manaCost;
            SkillType = skillType;
            SkillName = skillName;
            RemainingCooldown = 0;            
        }
    }
}