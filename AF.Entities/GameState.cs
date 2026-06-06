using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF.Entities.Characters.Enemies;
using AF.Entities.Characters.Players;

namespace AF.Entities
{
    public class GameState
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
    }
}