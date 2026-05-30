using AF.Entities.Characters;
using AF.Entities.Enums;
using AF.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items
{
    /// <summary>
    /// Base class for all items [EN]
    /// Tüm eşyalar için temel sınıf [TR]
    /// </summary>
    public abstract class Item : IItem
    {
        public string Name { get; protected set; } // Name of the item [EN] / Eşyanın adı [TR]
        public string Description { get; protected set; } // Description of the item [EN] / Eşyanın açıklaması [TR]
        public bool Consumable { get; protected set; } // Whether the item is consumed on use [EN] / Eşyanın kullanılıp kullanılmadığı [TR]
        public ItemType ItemType { get; protected set; } // Item Category (Damage, Healing, etc.) [EN] / Eşya Kategorisi (Hasar, İyileştirme, vb.) [TR]
        protected Item(string name, string description, ItemType itemType)
        {
            Name = name;
            Description = description;
            ItemType = itemType;
            Consumable = true;
        }
    }
}