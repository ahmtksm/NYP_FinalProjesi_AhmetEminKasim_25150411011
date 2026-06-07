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
    /// Yüksek kritik şansı olan karakter
    /// </summary>
    public class Assassin : Player
    {
        public Assassin() : base("Assassin", 90, new Stats(20, 5, 40, 30, 50), PlayerType.Assassin)
        {
            Skills.Add(new Backstab());
            Skills.Add(new Poison());

            Inventory.Add(new Bomb());
            Inventory.Add(new GreenHerb());
        }
    }
}