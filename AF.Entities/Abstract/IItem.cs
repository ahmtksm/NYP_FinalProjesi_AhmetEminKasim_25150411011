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
    /// Eşya davranışını temsil eder
    /// </summary>
    public interface IItem
    {
        string Name { get; } // Eşyanın adı
        string Description { get; } // Eşyanın açıklaması
        ItemType ItemType { get; } // Eşya kategorisi (Hasar, İyileştirme, vb.)
        ItemName ItemName { get; } // Belirli eşya adı (İksir vb.)
    }
}