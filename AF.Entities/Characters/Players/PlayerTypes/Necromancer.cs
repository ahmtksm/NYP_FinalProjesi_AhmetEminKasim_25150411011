using AF.Entities.Enums;
using AF.Entities.Items.ItemTypes.Healing;
using AF.Entities.Items.ItemTypes.Mana;
using AF.Entities.Skills.SkillTypes.Debuff;
using AF.Entities.Skills.SkillTypes.Heal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Players.PlayerTypes
{
    /// <summary>
    /// Karanlık büyücü, yaşam çalımı ve zehir üzerine odaklanır
    /// </summary>
    public class Necromancer : Player
    {
        public Necromancer() : base("Necromancer", 100, new Stats(18, 8, 10, 10, 90), PlayerType.Necromancer)
        {
            Skills.Add(new LifeDrain());
            Skills.Add(new Poison());

            Inventory.Add(new ManaPotion());
            Inventory.Add(new GreenHerb());
        }
    }
}