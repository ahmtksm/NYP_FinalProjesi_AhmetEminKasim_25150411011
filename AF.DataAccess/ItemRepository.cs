using AF.Core.Results;
using AF.Entities.Enums;
using AF.Entities.Interfaces;
using AF.Entities.Items.ItemTypes.Damage;
using AF.Entities.Items.ItemTypes.Defense;
using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Items.ItemTypes.Mana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DataAccess
{
    /// <summary>
    /// This repository is responsible for creating item instances based on the provided item type [EN]
    /// Bu depo, sağlanan eşya türüne göre eşya oluşturmakatan sorumludur [TR]
    /// </summary>
    public class ItemRepository
    {
        // This method creates an item instance based on the provided item type [EN]
        // Bu metot, sağlanan eşya türüne göre bir eşya oluşturur [TR]
        public IDataResult<IItem> CreateItem(ItemType ıtemType)
        {
            switch (ıtemType)
            {
                case ItemType.Damage: return new DataResult<IItem>(true, "Item created successfully.", new Bomb());
                case ItemType.Defense: return new DataResult<IItem>(true, "Item created successfully.", new DefensePotion());
                case ItemType.Healing: return new DataResult<IItem>(true, "Item created successfully.", new GreenHerb());
                case ItemType.Mana: return new DataResult<IItem>(true, "Item created successfully.", new ManaPotion());
                default: return new DataResult<IItem>(false, "Invalid item type.", null);
            }
        }
        // This method retrieves all available item types [EN]
        // Bu metot, mevcut tüm eşya türlerini listeler [TR]
        public List<ItemType> GetAllItemTypes()
        {
            return Enum.GetValues(typeof(ItemType)).Cast<ItemType>().ToList();
        }
    }
}