using AF.Entities.Enums;
using AF.Entities.Items.ItemTypes.Damage;
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
    /// Small, green, and sneaky creature [EN]
    /// küçük, yeşil, sinsi yaratık [TR]
    /// </summary>
    public class Goblin : Enemy
    {
        public Goblin(string name) : base("Goblin", 60, new Stats(10, 5, 5, 10, 10, 0), EnemyType.Goblin)
        {
            Skills.Add(new Backstab());
            Skills.Add(new Poison());

            Inventory.Add(new Bomb());
        }
    }
}