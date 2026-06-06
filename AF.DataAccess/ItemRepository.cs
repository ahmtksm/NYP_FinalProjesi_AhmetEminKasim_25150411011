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
    /// Bu depo, sağlanan eşya türüne göre eşya oluşturmakatan sorumludur
    /// </summary>
    public class ItemRepository
    {
        /// <summary>
        /// Bu metot, sağlanan eşya türüne göre bir eşya oluşturur
        /// </summary>
        public IDataResult<IItem> CreateItem(ItemName ıtemName)
        {
            switch (ıtemName)
            {
                case ItemName.Bomb: 
                    return new DataResult<IItem>(true, "Bomb successfully.", new Bomb());
                case ItemName.DefensePotion: 
                    return new DataResult<IItem>(true, "Defense Potion successfully.", new DefensePotion());
                case ItemName.GreenHerb: 
                    return new DataResult<IItem>(true, "Green herb successfully.", new GreenHerb());
                case ItemName.ManaPotion: 
                    return new DataResult<IItem>(true, "Mana Potion successfully.", new ManaPotion());
                default: 
                    return new DataResult<IItem>(false, "Invalid item name.", null);
            }
        }
    }
}