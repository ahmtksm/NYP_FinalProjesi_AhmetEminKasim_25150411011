using AF.Business.Abstract;
using AF.Core.Results;
using AF.Entities.Characters;
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
using AF.Entities.Items;

namespace AF.Business.Managers
{
    /// <summary>
    /// eşya kullanımı, etkilerinin uygulanması ve kullanıcı envanterinden kaldırılmasını yöneten servis
    /// </summary>
    public class ItemManager : IItemService
    {
        /// <summary>
        /// Eşyayı kullanır, etkilerini uygular ve envanter'den siler
        /// </summary>
        public IResult UseItem(Character user, Character target, IItem item)
        {
            // Kullanıcı ve hedef karakterin hayatta olup olmadığını kontrol eder
            if (!user.IsAlive) return new Result(false, $"{user.Name} is dead and cannot use items.", ResultType.Error);
            if (!target.IsAlive) return new Result(false, $"{target.Name} is dead.", ResultType.Error);

            // Kullanıcının envanterinde eşyayı kontrol eder
            if (!user.Inventory.Contains(item)) return new Result(false, "Item not found.", ResultType.Error);

            ApplyItemEffects(user, target, item); // Eşya efektlerini uygular          
            user.Inventory.Remove(item); // Kullanılan eşyayı envanterden siler.

            return new Result(true, $"{user.Name} used {item.Name} on {target.Name}.", ResultType.Success); // Başarılı bir şekilde eşya kullanıldığını belirten bir sonuç döner
        }

        /// <summary>
        /// Eşyaların türüne göre hedef karaktere etkisini uygular
        /// </summary>
        private void ApplyItemEffects(Character user, Character target, IItem item)
        {
            switch (item)
            {
                case Bomb bomb:
                    target.Health -= bomb.Damage; // Hedefe doğrudan hasar verir
                    break;
                case DefensePotion defensePotion: 
                    user.Stats.Defense += defensePotion.DefenseBoost; // Hedefin savunmasını geçici olarak artırır
                    break;
                case GreenHerb greenHerb:
                    user.Health += greenHerb.HealAmount; // Hedefin sağlığını iyileştirir
                    if (target.Health > target.MaxHealth) target.Health = target.MaxHealth; // Sağlığın maksimum sağlığı aşmasını engeller
                    break;
                case ManaPotion manaPotion:
                    user.Stats.Mana += manaPotion.ManaRestored; // Hedefin mana puanlarını yeniler
                    break;
            }
            if (target.Health < 0) target.Health = 0; // Sağlığın 0'ın altına düşmemesini sağlar
        }
    }
}