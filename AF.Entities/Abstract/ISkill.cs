using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Abstract
{
    /// <summary>
    /// Represents skill behavior [EN]
    /// Beceri davranışını temsil eder [TR]
    /// </summary>
    public interface ISkill
    {
        string Name { get; } // Name of the skill [EN] / Beceri adı [TR]
        string Description { get; } // Description of the skill's effect [EN] / Beceri etkisinin açıklaması [TR]
        int Cooldown { get; } // Cooldown time in turns [EN] / Beceri kullanımından sonra beklenmesi gereken tur sayısı [TR]
        int RemainingCooldown { get; set; } // Remaining cooldown time in turns [EN] / Kalan bekleme süresi (tur cinsinden) [TR]
        int ManaCost { get; } // Mana cost to use the skill [EN] / Beceri kullanmak için gereken mana miktarı [TR]
        SkillType SkillType { get; } // Skill Category (Damage, Healing, Buff, Debuff, etc.) [EN] / Beceri kategorisi (Hasar, İyileştirme, Güçlendirme, Zayıflatma, vb.) [TR]
        SkillName SkillName { get; } // Enum value for the skill name [EN] / Beceri adı için enum değeri [TR]
    }
}