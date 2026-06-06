using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF.Entities.Characters.Enemies;
using AF.Entities.Characters.Players;

namespace AF.Entities
{
    /// <summary>
    /// Oyunun mevcut durumunu temsil eden sınıf. Oyuncu ve düşman bilgilerini içerir.
    /// </summary>
    public class GameState
    {
        public Player Player { get; set; } // Oyuncu bilgilerini tutar
        public Enemy Enemy { get; set; } // Düşman bilgilerini tutar
    }
}