using AF.Entities.Enums;
using AF.Entities.Items.ItemTypes.Defense;
using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Skills.SkillTypes.Buff;
using AF.Entities.Skills.SkillTypes.Heal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Players.PlayerTypes
{
    /// <summary>
    /// Savunma ve iyileştirmede iyi olan bir karakter.
    /// </summary>
    public class Paladin : Player
    {
        public Paladin() : base("Paladin", 150, new Stats(20, 20, 10, 5, 60), PlayerType.Paladin)
        {
            Skills.Add(new Heal());
            Skills.Add(new Shield());

            Inventory.Add(new DefensePotion());
            Inventory.Add(new GreenHerb());
        }
    }
}