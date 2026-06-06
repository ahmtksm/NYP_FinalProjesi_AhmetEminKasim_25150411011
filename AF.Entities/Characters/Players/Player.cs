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
    /// Oynanabilir karakteri temsil eder
    /// </summary>
    public class Player : Character
    {
        public PlayerType PlayerType { get; protected set; } // Oyuncu türü (Knight, Assassin vs.)
        public Player(string name, int maxHealth, Stats stats, PlayerType playerType) : base(name, maxHealth, stats)
        {
            PlayerType = playerType;
        }
    }
}