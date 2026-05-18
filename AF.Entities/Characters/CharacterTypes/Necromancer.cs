using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Items.ItemTypes.Mana;
using AF.Entities.Skills.SkillTypes.Debuff;
using AF.Entities.Skills.SkillTypes.Heal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.CharacterTypes
{
    /// <summary>
    /// Dark magic user focused on life steal and poison
    /// </summary>
    public class Necromancer : Character
    {
        public Necromancer(string name) : base("Necromancer", 100, new Stats(18, 8, 10, 10, 12, 90)) // Creates a new necromancer character
        {
            Skills.Add(new LifeDrain());
            Skills.Add(new Poison());

            Inventory.Add(new ManaPotion());
            Inventory.Add(new GreenHerb());
        }
    }
}
