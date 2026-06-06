using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Items.ItemTypes.Defense
{
    /// <summary>
    /// Savunmayı artıran iksir
    /// </summary>
    public class DefensePotion : Item
    {
        public int DefenseBoost { get; private set; } // İksirin sağladığı savunma artışı miktarı
        public DefensePotion() : base("Defense Potion", "A potion that increases defense", ItemType.Defense, ItemName.DefensePotion)
        {
            DefenseBoost = 10;
        }
    }
}