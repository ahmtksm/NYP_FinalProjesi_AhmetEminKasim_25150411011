using AF.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Characters.Players
{
    /// <summary>
    /// Represents the playable character controlled by the user [EN]
    /// Oynanabilir karakteri temsil eder [TR]
    /// </summary>
    public class Player : Character
    {
        public Player(string name, int maxHealth, Stats stats) : base(name, maxHealth, stats)
        {

        }
    }
}