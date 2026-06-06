using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items.ItemTypes.Mana
{
    /// <summary>
    /// Mana yenileyen iksir 
    /// </summary>
    public class ManaPotion : Item
    {
        public int ManaRestored { get; private set; } // İksirin yenilediği mana miktarı
        public ManaPotion() : base("Mana Potion", "A potion that restores mana", ItemType.Mana, ItemName.ManaPotion)
        {
            ManaRestored = 25;
        }
    }
}