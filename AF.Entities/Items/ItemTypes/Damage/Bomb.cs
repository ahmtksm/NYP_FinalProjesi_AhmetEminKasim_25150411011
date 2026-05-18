using AF.Core.Enums;
using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items.ItemTypes.Damage
{
    /// <summary>
    /// Explosive item that damages enemies
    /// </summary>
    public class Bomb : Item
    {
        public int Damage { get; private set; } // Damage dealt to enemies
        public Bomb() : base("Bomb", "A powerful explosive", ItemType.Damage) // Creates a new Bomb item with a name, description, and type
        {
            Damage = 30;
        }
    }
}
