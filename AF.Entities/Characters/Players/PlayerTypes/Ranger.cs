using AF.Entities.Items.ItemTypes.Damage;
using AF.Entities.Items.ItemTypes.Healing;
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
    /// Agile ranged fighter with balanced combat abilities [EN]
    /// Hafif ve uzaktan dövüşen savaşçı, dengeli combat yetenekleriyle bilinir [TR]
    /// </summary>
    public class Ranger : Player
    {
        public Ranger(string name) : base("Ranger", 110, new Stats(22, 10, 20, 20, 18, 50))
        {
            Skills.Add(new Backstab());
            Skills.Add(new Burn());

            Inventory.Add(new Bomb());
            Inventory.Add(new GreenHerb());
        }
    }
}