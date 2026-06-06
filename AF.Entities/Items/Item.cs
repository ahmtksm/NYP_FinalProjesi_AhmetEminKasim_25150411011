using AF.Entities.Characters;
using AF.Entities.Enums;
using AF.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items
{
    /// <summary>
    /// Tüm eşyalar için temel sınıf
    /// </summary>
    public abstract class Item : IItem
    {
        public string Name { get; protected set; } // Eşyanın adı
        public string Description { get; protected set; } // Eşyanın açıklaması
        public bool Consumable { get; protected set; } // Eşyanın kullanılıp kullanılmadığı
        public ItemType ItemType { get; protected set; } // Eşya Kategorisi (Hasar, İyileştirme, vb.)
        public ItemName ItemName {  get; protected set; } // Eşyanın enum adı
        protected Item(string name, string description, ItemType itemType, ItemName ıtemName)
        {
            Name = name;
            Description = description;
            ItemType = itemType;
            ItemName = ıtemName;
            Consumable = true;        
        }
    }
}