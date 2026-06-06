using AF.Core.Results;
using AF.Entities.Enums;
using AF.Entities.Abstract;
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
        public IDataResult<IItem> CreateItem(ItemName ıtemName)
        {
            switch (ıtemName)
            {
                case ItemName.Bomb: return new DataResult<IItem>(true, "Item created successfully.", new Bomb());
                case ItemName.DefensePotion: return new DataResult<IItem>(true, "Item created successfully.", new DefensePotion());
                case ItemName.GreenHerb: return new DataResult<IItem>(true, "Item created successfully.", new GreenHerb());
                case ItemName.ManaPotion: return new DataResult<IItem>(true, "Item created successfully.", new ManaPotion());
                default: return new DataResult<IItem>(false, "Invalid item name.", null);
            }
        }
        // This method retrieves all available item names [EN]
        // Bu metot, mevcut tüm eşya isimlerini listeler [TR]
        public List<ItemName> GetAllItemNames()
        {
            return Enum.GetValues(typeof(ItemName)).Cast<ItemName>().ToList();
        }
    }
}