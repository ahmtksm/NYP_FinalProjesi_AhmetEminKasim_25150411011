using AF.Entities.Enums;
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
    /// Dengeli combat yetenekleriyle bilinir
    /// </summary>
    public class Ranger : Player
    {
        public Ranger() : base("Ranger", 110, new Stats(22, 10, 20, 20, 50), PlayerType.Ranger)
        {
            Skills.Add(new Backstab());
            Skills.Add(new Burn());

            Inventory.Add(new Bomb());
            Inventory.Add(new GreenHerb());
        }
    }
}