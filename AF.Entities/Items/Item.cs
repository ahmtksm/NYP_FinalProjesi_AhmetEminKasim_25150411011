using AF.Core.Enums;
using AF.Entities.Characters;
using AF.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items
{
    /// <summary>
    /// Base class for all items
    /// </summary>
    public abstract class Item : IItem
    {
        public string Name { get; protected set; } // Name of the item
        public string Description { get; protected set; } // Description of the item
        public bool Consumable { get; protected set; } // Whether the item is consumed on use
        public ItemType ItemType { get; protected set; } // Item Category (Damage, Healing, etc.)
        protected Item(string name, string description, ItemType itemType) // Constructor to initialize item properties
        {
            Name = name;
            Description = description;
            ItemType = itemType;
            Consumable = true;
        }
    }
}
