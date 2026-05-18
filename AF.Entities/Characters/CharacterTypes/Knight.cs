using AF.Entities.Items.ItemTypes.Defense;
using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Skills.SkillTypes.Buff;
using AF.Entities.Skills.SkillTypes.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.CharacterTypes
{
    /// <summary>
    /// Defensive warrior with high armor
    /// </summary>
    public class Knight : Character
    {
        public Knight(string name) : base("Knight", 160, new Stats(20, 25, 10, 5, 8, 25)) // Creates a new knight character
        {
            Skills.Add(new Shield());
            Skills.Add(new BloodSlash());

            Inventory.Add(new DefensePotion());
            Inventory.Add(new GreenHerb());
        }
    }
}
