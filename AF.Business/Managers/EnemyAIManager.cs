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
        /// <summary>
        /// Düşmanın bu turda hangi eylemi gerçekleştireceğini belirleyen metod
        /// </summary>
        public ActionType ChooseAction(Enemy enemy) 
        {
            int rndm = Random.Shared.Next(100); // Düşmanın kararları için random değeri

            // Canı düşükse ve iyileştirme eşyası varsa %60 ihtimalle kullanır
            if (enemy.Health <= enemy.MaxHealth * 0.3 && enemy.Inventory.Any(i => i is GreenHerb) && rndm < 60) return ActionType.UseItem;

            // Manası yeterli ise %40 ihtimalle yetenek kullanır
            if (enemy.Skills.Any() && enemy.Stats.Mana >= enemy.Skills.Min(s => s.ManaCost) && enemy.Skills.Any(s => s.RemainingCooldown == 0) && rndm < 40) return ActionType.Skill;
            
            if (rndm < 20) return ActionType.Defense; // %20 ihtimalle savunma yapar

            return ActionType.Attack; // Varsayılan olarak saldırır
        }

        /// <summary>
        /// Kullanılabilecek bir yetenek seç
        /// </summary>
        public ISkill? ChooseSkill(Enemy enemy) 
        {
            return enemy.Skills.FirstOrDefault(s => s.RemainingCooldown == 0 && enemy.Stats.Mana >= s.ManaCost);
        }

        /// <summary>
        /// Kullanılabilecek bir eşya seç
        /// </summary>
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