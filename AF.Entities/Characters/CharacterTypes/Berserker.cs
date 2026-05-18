using AF.Entities.Items.ItemTypes.Damage;
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
    /// Heavy melee fighter with high damage
    /// </summary>
    public class Berserker : Character
    {
        public Berserker(string name) : base("Berserker", 140, new Stats(35, 10, 15, 5, 10, 30)) // Creates a new berserker character
        {
            Skills.Add(new Rage());
            Skills.Add(new BloodSlash());

            Inventory.Add(new Bomb());
            Inventory.Add(new GreenHerb());
        }
    }
}
