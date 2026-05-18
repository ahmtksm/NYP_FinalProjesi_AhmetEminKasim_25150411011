using AF.Core.Enums;
using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Interfaces
{
    /// <summary>
    /// Represents an item behavior
    /// </summary>
    public interface IItem
    {
        string Name { get; } // Name of the item
        string Description { get; } // Description of the item
        ItemType ItemType { get; } // Item Category (Damage, Healing, etc.)
    }
}
