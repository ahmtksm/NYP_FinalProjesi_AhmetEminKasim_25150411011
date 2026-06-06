using AF.Entities.Enums;
using AF.Entities.Abstract;
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
        public PlayerType PlayerType { get; protected set; } // Type of player (e.g., Warrior, Mage) [EN] / Oyuncu türü (örneğin, Savaşçı, Büyücü) [TR]
        public Player(string name, int maxHealth, Stats stats, PlayerType playerType) : base(name, maxHealth, stats)
        {
            PlayerType = playerType;
        }
    }
}