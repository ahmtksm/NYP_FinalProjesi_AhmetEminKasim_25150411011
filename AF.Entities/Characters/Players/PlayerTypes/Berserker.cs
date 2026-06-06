using AF.Entities.Enums;
using AF.Entities.Items.ItemTypes.Damage;
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
    /// Ağırlıklı yakın dövüşçü, yüksek hasar verir
    /// </summary>
    public class Berserker : Player
    {
        public Berserker() : base("Berserker", 140, new Stats(35, 10, 15, 5, 30), PlayerType.Berserker)
        {
            Skills.Add(new Rage());
            Skills.Add(new BloodSlash());

            Inventory.Add(new Bomb());
            Inventory.Add(new GreenHerb());
        }
    }
}