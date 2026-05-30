using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items.ItemTypes.Healing
{
    /// <summary>
    /// Healing item that restores health [EN]
    /// Sağlığı yenileyen eşya [TR]
    /// </summary>
    public class GreenHerb : Item
    {
        public int HealAmount { get; private set; } // Amount of restored health [EN] / Yenilenen sağlık miktarı [TR]
        public GreenHerb() : base("Green Herb", "A simple healing herb", ItemType.Healing)
        {
            HealAmount = 20;
        }
    }
}