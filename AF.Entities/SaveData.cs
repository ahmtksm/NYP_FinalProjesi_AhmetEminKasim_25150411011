using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities
{
    /// <summary>
    /// Oyunun durumunu kaydetmek için kullanılan veri yapısını temsil eder
    /// </summary>
    public class SaveData
    {
        public string PlayerName { get; set; } // Oyuncunun adı
        public PlayerType PlayerType { get; set; } // Oyuncu türü (örneğin, Savaşçı, Büyücü)
        public int Health { get; set; } // Oyuncunun sağlığı
        public int Mana { get; set; } // Oyuncunun manası
        public List<ItemName> Inventory { get; set; } // Oyuncunun envanteri
        public List<SkillName> Skills { get; set; } // Oyuncunun becerileri
        public EnemyType EnemyType { get; set; } // Düşman türü (örneğin, Goblin, Ork)
        public string EnemyName { get; set; } // Düşmanın adı
        public int EnemyHealth { get; set; } // Düşmanın sağlığı
        public int EnemyMana { get; set; } // Düşmanın manası
    }
}