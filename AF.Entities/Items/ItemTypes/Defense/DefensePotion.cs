using AF.Core.Enums;
using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items.ItemTypes.Defense
{
    /// <summary>
    /// Potion that increases the defense
    /// </summary>
    public class DefensePotion : Item
    {
        public int DefenseBoost { get; private set; } // The amount of defense boost provided by the potion
        public DefensePotion() : base("Defense Potion", "A potion that increases defense", ItemType.Defense) // Creates a new Defense Potion item with a name, description, and type
        {
            DefenseBoost = 10;
        }
    }
}
