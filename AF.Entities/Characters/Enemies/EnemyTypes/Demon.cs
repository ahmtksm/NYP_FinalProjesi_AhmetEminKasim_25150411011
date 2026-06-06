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
    /// Karanlık büyü yeteneklerine sahip güçlü ve kötü niyetli bir yaratık.
    /// </summary>
    public class Demon : Enemy
    {
        public Demon() : base("Demon", 150, new Stats(35, 20, 15, 5, 30), EnemyType.Demon)
        {
            Skills.Add(new Fireball());
            Skills.Add(new Burn());
            Skills.Add(new LifeDrain());

            Inventory.Add(new DefensePotion());
        }
    }
}