using AF.Business.Abstract;
using AF.Core;
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

namespace AF.Business.Managers
{
    /// <summary>
    /// eşya kullanımı, etkilerinin uygulanması ve kullanıcı envanterinden kaldırılmasını yöneten servis
    /// </summary>
    public class ItemManager : IItemService
    {
        // Eşyayı kullanır, etkilerini uygular ve envanter'den siler
        public IResult UseItem(Character user, Character target, IItem item)
        {
            // Kullanıcı ve hedef karakterin hayatta olup olmadığını kontrol eder
            if (!user.IsAlive) return new Result(false, $"{user.Name} is dead and cannot use items.", ResultType.Error);
            if (!target.IsAlive) return new Result(false, $"{target.Name} is dead.", ResultType.Error);

            // Kullanıcının envanterinde eşyayı kontrol eder
            if (!user.Inventory.Contains(item)) return new Result(false, "Item not found.", ResultType.Error);

            ApplyItemEffects(target, item);           
            user.Inventory.Remove(item);

            return new Result(true, $"{user.Name} used {item.Name} on {target.Name}.", ResultType.Success);
        }

        // Eşyaların türüne göre hedef karaktere etkisini uygular
        private void ApplyItemEffects(Character target, IItem item) 
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
            if (target.Health < 0) target.Health = 0; // Sağlığın 0'ın altına düşmemesini sağlar
        }
    }
}