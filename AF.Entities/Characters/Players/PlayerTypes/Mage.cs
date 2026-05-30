using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Items.ItemTypes.Mana;
using AF.Entities.Skills.SkillTypes.Damage;
using AF.Entities.Skills.SkillTypes.Debuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Players.PlayerTypes
{
    /// <summary>
    /// Magic user with powerful elemental attacks [EN]
    /// Güçlü elementel saldırılar yapan büyücü [TR]
    /// </summary>
    public class Mage : Player
    {
        public Mage(string name) : base("Mage", 80, new Stats(15, 5, 15, 10, 15, 100))
        {
            Skills.Add(new Fireball());
            Skills.Add(new Freeze());
            Skills.Add(new Burn());

            Inventory.Add(new ManaPotion());
            Inventory.Add(new GreenHerb());
        }
    }
}