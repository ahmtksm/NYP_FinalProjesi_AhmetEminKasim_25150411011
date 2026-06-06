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
    /// Potion item that restores mana [EN]
    /// Mana restore eden iksir [TR]
    /// </summary>
    public class ManaPotion : Item
    {
        public int ManaRestored { get; private set; } // The amount of mana restored by the potion [EN] / İksirin restore ettiği mana miktarı [TR]
        public ManaPotion() : base("Mana Potion", "A potion that restores mana", ItemType.Mana, ItemName.ManaPotion)
        {
            ManaRestored = 25;
        }
    }
}