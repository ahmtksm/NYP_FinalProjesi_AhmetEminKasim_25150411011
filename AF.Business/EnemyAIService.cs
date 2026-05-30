using AF.Business.Interfaces;
using AF.Entities.Characters.Enemies;
using AF.Entities.Enums;
using AF.Entities.Interfaces;
using AF.Entities.Items.ItemTypes.Healing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business
{
    /// <summary>
    /// Service for determining enemy actions [EN]
    /// Düşman eylemlerini belirleyen servis [TR]
    /// </summary>
    public class EnemyAIService : IEnemyAIService
    {
        // Random instance for AI decisions [EN]
        // AI kararları için rastgele değer [TR]
        private readonly Random random;
        public EnemyAIService()
        {
            random = new Random();
        }
        // Decide which action the enemy should perform this turn [EN]
        // Düşmanın bu turda hangi eylemi gerçekleştireceğini belirleyen metod [TR]
        public ActionType ChooseAction(Enemy enemy)
        {
            if (enemy.Health <= enemy.MaxHealth * 0.3 && enemy.Inventory.Any(i => i is GreenHerb)) return ActionType.UseItem;

            if (enemy.Skills.Any() && enemy.Stats.Mana >= enemy.Skills.Min(s => s.ManaCost) && enemy.Skills.Any(s => s.RemainingCooldown == 0)) return ActionType.Skill;

            int rndm = random.Next(100);
            if (rndm < 20) return ActionType.Defense;

            return ActionType.Attack;
        }
        // Select an available skill that can currently be used [EN]
        // Şu anda kullanılabilecek bir yetenek seç [TR]
        public ISkill? ChooseSkill(Enemy enemy)
        {
            return enemy.Skills.FirstOrDefault(s => s.RemainingCooldown == 0 && enemy.Stats.Mana >= s.ManaCost);
        }
        // Select an item to use when health is low [EN]
        // Sağlık düşük olduğunda kullanılacak bir eşya seç [TR]
        public IItem? ChooseItem(Enemy enemy)
        {
            if (enemy.Health <= enemy.MaxHealth * 0.3)
            {
                return enemy.Inventory.FirstOrDefault(i => i is GreenHerb);
            }

            return null; // No item needed if health is not low [EN] / Sağlık düşük değilse eşya gerekmez [TR]
        }
    }
}