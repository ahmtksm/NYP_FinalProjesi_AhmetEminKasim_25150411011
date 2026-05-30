using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Interfaces
{
    /// <summary>
    /// Represents an item behavior [EN]
    /// Eşya davranışını temsil eder [TR]
    /// </summary>
    public interface IItem
    {
        string Name { get; } // Name of the item [EN] / Eşyanın adı [TR]
        string Description { get; } // Description of the item [EN] / Eşyanın açıklaması [TR]
        ItemType ItemType { get; } // Item Category (Damage, Healing, etc.) [EN] / Eşya kategorisi (Hasar, İyileştirme, vb.) [TR]
    }
}