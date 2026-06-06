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
    /// Dark magic user focused on life steal and poison [EN]
    /// Karanlık büyücü, yaşam çalımı ve zehir üzerine odaklanır [TR]
    /// </summary>
    public class Necromancer : Player
    {
        public Necromancer(string name) : base("Necromancer", 100, new Stats(18, 8, 10, 10, 12, 90), PlayerType.Necromancer)
        {
            Skills.Add(new LifeDrain());
            Skills.Add(new Poison());

            Inventory.Add(new ManaPotion());
            Inventory.Add(new GreenHerb());
        }
    }
}