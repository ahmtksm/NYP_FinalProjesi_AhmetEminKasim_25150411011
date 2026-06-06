using AF.Entities.Enums;
using AF.Entities.Items.ItemTypes.Mana;
using AF.Entities.Skills.SkillTypes.Damage;
using AF.Entities.Skills.SkillTypes.Debuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Enemies.EnemyTypes
{
    /// <summary>
    /// Güçlü sihirbaz, yüksek hasar çıkışı ama düşük savunma ile bilinir
    /// </summary>
    public class DarkMage : Enemy
    {
        public DarkMage() : base("DarkMage", 80, new Stats(25, 5, 10, 10, 50), EnemyType.DarkMage)
        {
            Skills.Add(new Fireball());
            Skills.Add(new Burn());
            Skills.Add(new Freeze());

            Inventory.Add(new ManaPotion());
        }
    }
}