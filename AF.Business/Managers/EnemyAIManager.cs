using AF.Business.Abstract;
using AF.Entities.Characters.Enemies;
using AF.Entities.Enums;
using AF.Entities.Abstract;
using AF.Entities.Items.ItemTypes.Healing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Managers
{
    /// <summary>
    /// Düşman eylemlerini belirleyen servis
    /// </summary>
    public class EnemyAIManager : IEnemyAIService
    {        
        private readonly Random random; // AI kararları için rastgele değer
        public EnemyAIManager()
        {
            random = new Random();
        }

        // Düşmanın bu turda hangi eylemi gerçekleştireceğini belirleyen metod
        public ActionType ChooseAction(Enemy enemy) 
        {
            int rndm = random.Next(100);

            // Canı düşükse ve iyileştirme eşyası varsa %50 ihtimalle kullanır
            if (enemy.Health <= enemy.MaxHealth * 0.3 && enemy.Inventory.Any(i => i is GreenHerb) && rndm < 50) return ActionType.UseItem;

            // Manası yeterli ise %30 ihtimalle yetenek kullanır
            if (enemy.Skills.Any() && enemy.Stats.Mana >= enemy.Skills.Min(s => s.ManaCost) && enemy.Skills.Any(s => s.RemainingCooldown == 0) && rndm < 30) return ActionType.Skill;

            // %20 ihtimalle savunma yapar
            if (rndm < 20) return ActionType.Defense;

            // Varsayılan olarak saldırır
            return ActionType.Attack; 
        }

        // Kullanılabilecek bir yetenek seç
        public ISkill? ChooseSkill(Enemy enemy) 
        {
            return enemy.Skills.FirstOrDefault(s => s.RemainingCooldown == 0 && enemy.Stats.Mana >= s.ManaCost);
        }

        // Kullanılabilecek bir eşya seç
        public IItem? ChooseItem(Enemy enemy) 
        {
            if (enemy.Health <= enemy.MaxHealth * 0.3)
            {
                return enemy.Inventory.FirstOrDefault(i => i is GreenHerb);
            }

            return null;
        }
    }
}