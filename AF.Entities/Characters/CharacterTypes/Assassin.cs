using AF.Entities.Characters;
using AF.Entities.Items.ItemTypes.Damage;
using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Skills.SkillTypes.Damage;
using AF.Entities.Skills.SkillTypes.Debuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.CharacterTypes
{
    /// <summary>
    /// Fast character with high critical chance
    /// </summary>
    public class Assassin : Character
    {
        public Assassin(string name) : base("Assassin", 90, new Stats(20, 5, 40, 30, 25, 50)) // Creates a new assassin character
        {
            Skills.Add(new Backstab());
            Skills.Add(new Poison());

            Inventory.Add(new Bomb());
            Inventory.Add(new GreenHerb());
        }
    }
}
