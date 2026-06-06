using AF.Entities.Enums;
using AF.Entities.Items.ItemTypes.Defense;
using AF.Entities.Items.ItemTypes.Mana;
using AF.Entities.Skills.SkillTypes.Buff;
using AF.Entities.Skills.SkillTypes.Damage;
using AF.Entities.Skills.SkillTypes.Debuff;
using AF.Entities.Skills.SkillTypes.Heal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Enemies.EnemyTypes
{
    /// <summary>
    /// A powerful and malevolent creature with dark magic abilities [EN]
    /// Karanlık büyü yeteneklerine sahip güçlü ve kötü niyetli bir yaratık. [TR]
    /// </summary>
    public class Demon : Enemy
    {
        public Demon(string name) : base("Demon", 150, new Stats(35, 20, 15, 5, 10, 30), EnemyType.Demon)
        {
            Skills.Add(new Fireball());
            Skills.Add(new Burn());
            Skills.Add(new Rage());
            Skills.Add(new LifeDrain());

            Inventory.Add(new DefensePotion());
            Inventory.Add(new ManaPotion());
        }
    }
}