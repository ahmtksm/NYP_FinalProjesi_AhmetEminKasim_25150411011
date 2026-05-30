using AF.Business.Interfaces;
using AF.Core;
using AF.Core.Results;
using AF.Entities.Characters;
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

namespace AF.Business
{
    /// <summary>
    /// a service that handles the logic for using items, applying their effects, and removing them from the user's inventory [EN]
    /// eşya kullanımı, etkilerinin uygulanması ve kullanıcı envanterinden kaldırılmasını yöneten servis [TR]
    /// </summary>
    public class ItemService : IItemService
    {
        // Uses an item on a target character, applying its effects and removing it from the user's inventory [EN]
        // Eşyayı kullanır, etkilerini uygular ve envanter'den siler [TR]
        public IResult UseItem(Character user, Character target, IItem item)
        {
            // Checks if both characters are alive before proceeding with the item use [EN]
            // Eşya kullanma işlemine devam etmeden önce her iki karakterin de canlı olup olmadığını kontrol eder [TR]
            if (!user.IsAlive) return new ErrorResult($"{user.Name} is dead and cannot use items.");
            if (!target.IsAlive) return new ErrorResult($"{target.Name} is dead.");

            // Checks if the item exists in the user's inventory [EN]
            // Kullanıcının envanterinde eşyanın bulunup bulunmadığını kontrol eder [TR]
            if (!user.Inventory.Contains(item)) return new ErrorResult("Item not found."); 

            ApplyItemEffects(target, item);           
            user.Inventory.Remove(item);

            return new SuccessResult($"{user.Name} used {item.Name} on {target.Name}.");
        }
        // Applies the effect of the item to the target character based on the item type [EN]
        // Eşyaların türüne göre hedef karaktere etkisini uygular [TR]
        private void ApplyItemEffects(Character target, IItem item) // Applies the effect of the item
        {
            switch (item)
            {
                case Bomb bomb:
                    target.Health -= bomb.Damage;
                    break;
                case DefensePotion defensePotion:
                    target.Stats.Defense += defensePotion.DefenseBoost;
                    break;
                case GreenHerb greenHerb:
                    target.Health += greenHerb.HealAmount;
                    if (target.Health > target.MaxHealth) target.Health = target.MaxHealth;
                    break;
                case ManaPotion manaPotion:
                    target.Stats.Mana += manaPotion.ManaRestored;
                    break;
            }
            if (target.Health < 0) target.Health = 0; // Ensures health does not drop below 0 [EN] / Sağlığın 0'ın altına düşmemesini sağlar [TR]
        }
    }
}