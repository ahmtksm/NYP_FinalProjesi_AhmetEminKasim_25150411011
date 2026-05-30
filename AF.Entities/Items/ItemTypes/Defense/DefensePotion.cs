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
    /// Potion that increases the defense [EN]
    /// Savunmayı artıran iksir [TR]
    /// </summary>
    public class DefensePotion : Item
    {
        public int DefenseBoost { get; private set; } // The amount of defense boost provided by the potion [EN] / İksirin sağladığı savunma artışı miktarı [TR]
        public DefensePotion() : base("Defense Potion", "A potion that increases defense", ItemType.Defense)
        {
            DefenseBoost = 10;
        }
    }
}