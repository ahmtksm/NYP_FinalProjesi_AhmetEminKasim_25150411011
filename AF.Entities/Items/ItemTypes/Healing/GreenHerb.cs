using AF.Core.Enums;
using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items.ItemTypes.Healing
{
    /// <summary>
    /// Healing item that restores health
    /// </summary>
    public class GreenHerb : Item
    {
        public int HealAmount { get; private set; } // Amount of restored health
        public GreenHerb() : base("Green Herb", "A simple healing herb", ItemType.Healing) // Creates a new Green Herb item with a name, description, and type
        {
            HealAmount = 20;
        }
    }
}
