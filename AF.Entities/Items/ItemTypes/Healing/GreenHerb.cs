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
    /// Sağlığı yenileyen eşya
    /// </summary>
    public class GreenHerb : Item
    {
        public int HealAmount { get; private set; } // Yenilenen sağlık miktarı
        public GreenHerb() : base("Green Herb", "A simple healing herb", ItemType.Healing, ItemName.GreenHerb)
        {
            HealAmount = 20;
        }
    }
}