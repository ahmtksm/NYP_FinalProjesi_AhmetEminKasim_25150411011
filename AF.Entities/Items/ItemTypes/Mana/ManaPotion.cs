using AF.Core.Enums;
using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items.ItemTypes.Mana
{
    /// <summary>
    /// Potion item that restores mana
    /// </summary>
    public class ManaPotion : Item
    {
        public int ManaRestored { get; private set; } // The amount of mana restored by the potion
        public ManaPotion() : base("Mana Potion", "A potion that restores mana", ItemType.Mana) // Creates a new Mana Potion item with a name, description, and type
        {
            ManaRestored = 25;
        }
    }
}
