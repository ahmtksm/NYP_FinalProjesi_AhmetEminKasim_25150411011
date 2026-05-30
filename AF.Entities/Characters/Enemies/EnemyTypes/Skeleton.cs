using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Skills.SkillTypes.Buff;
using AF.Entities.Skills.SkillTypes.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Enemies.EnemyTypes
{
    /// <summary>
    /// Undead enemy that relies on physical attacks and has moderate health [EN]
    /// Fiziksel saldırılara dayanan ve orta düzeyde sağlığa sahip düşman [TR]
    /// </summary>
    public class Skeleton : Enemy
    {
        public Skeleton(string name) : base("Skeleton", 70, new Stats(15, 5, 10, 5, 10, 0))
        {
            Skills.Add(new Shield());
            Skills.Add(new BloodSlash());

            Inventory.Add(new GreenHerb());
        }
    }
}