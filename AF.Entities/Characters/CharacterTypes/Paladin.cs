using AF.Entities.Items.ItemTypes.Defense;
using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Skills.SkillTypes.Buff;
using AF.Entities.Skills.SkillTypes.Heal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.CharacterTypes
{
    /// <summary>
    /// Holy warrior with defensive and healing abilities
    /// </summary>
    public class Paladin : Character
    {
        public Paladin(string name) : base("Paladin", 150, new Stats(20, 20, 10, 5, 8, 60)) // Creates a new paladin character
        {
            Skills.Add(new Heal());
            Skills.Add(new Shield());

            Inventory.Add(new DefensePotion());
            Inventory.Add(new GreenHerb());
        }
    }
}
