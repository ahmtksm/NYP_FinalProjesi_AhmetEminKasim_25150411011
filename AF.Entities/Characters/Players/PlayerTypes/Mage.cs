using AF.Entities.Enums;
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
    /// Güçlü elementel saldırılar yapan büyücü
    /// </summary>
    public class Mage : Player
    {
        public Mage() : base("Mage", 80, new Stats(15, 5, 15, 10, 100), PlayerType.Mage)
        {
            Skills.Add(new Fireball());
            Skills.Add(new Freeze());
            Skills.Add(new Burn());

            Inventory.Add(new ManaPotion());
            Inventory.Add(new GreenHerb());
        }
    }
}