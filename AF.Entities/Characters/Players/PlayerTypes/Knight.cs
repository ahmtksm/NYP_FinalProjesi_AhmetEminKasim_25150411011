using AF.Entities.Enums;
using AF.Entities.Items.ItemTypes.Defense;
using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Skills.SkillTypes.Buff;
using AF.Entities.Skills.SkillTypes.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Players.PlayerTypes
{
    /// <summary>
    /// Defensive warrior with high armor [EN]
    /// Yüksek zırhı olan savunma odaklı savaşçı [TR]
    /// </summary>
    public class Knight : Player
    {
        public Knight(string name) : base("Knight", 160, new Stats(20, 25, 10, 5, 8, 25), PlayerType.Knight)
        {
            Skills.Add(new Shield());
            Skills.Add(new BloodSlash());

            Inventory.Add(new DefensePotion());
            Inventory.Add(new GreenHerb());
        }
    }
}