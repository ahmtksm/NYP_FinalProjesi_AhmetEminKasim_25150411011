using AF.Entities.Items.ItemTypes.Defense;
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
    /// Strong and aggressive enemy type [EN]
    /// Güçlü ve agresif bir düşman türünü temsil eder [TR]
    /// </summary>
    public class Orc : Enemy
    {
        public Orc(string name) : base("Orc", 100, new Stats(20, 10, 5, 5, 5, 0))
        {
            Skills.Add(new Rage());
            Skills.Add(new BloodSlash());

            Inventory.Add(new DefensePotion());
        }
    }
}