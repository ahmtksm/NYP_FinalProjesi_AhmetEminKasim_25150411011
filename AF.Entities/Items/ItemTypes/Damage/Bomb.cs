using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items.ItemTypes.Damage
{
    /// <summary>
    /// Düşmanlara zarar veren patlayıcı eşya
    /// </summary>
    public class Bomb : Item
    {
        public int Damage { get; private set; } // Düşmanlara verilen hasar
        public Bomb() : base("Bomb", "A powerful explosive", ItemType.Damage, ItemName.Bomb)
        {
            Damage = 30;
        }
    }
}