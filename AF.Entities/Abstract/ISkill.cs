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
    /// Beceri davranışını temsil eder
    /// </summary>
    public interface ISkill
    {
        string Name { get; } // Beceri adı
        string Description { get; } // Beceri etkisinin açıklaması
        int Cooldown { get; } // Beceri kullanımından sonra beklenmesi gereken tur sayısı
        int RemainingCooldown { get; set; } // Kalan bekleme süresi (tur cinsinden)
        int ManaCost { get; } // Beceri kullanmak için gereken mana miktarı
        SkillType SkillType { get; } // Beceri kategorisi (Hasar, İyileştirme, Güçlendirme, Zayıflatma, vb.)
        SkillName SkillName { get; } // Beceri adı için enum değeri
    }
}