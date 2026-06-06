using AF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DataAccess.Abstract
{
    /// <summary>
    /// Defines the contract for saving and loading game data [EN]
    /// Oyun verilerini kaydetmek ve yüklemek için depo [TR]
    /// </summary>
    public interface ISaveRepository
    {
        void SaveGame(SaveData saveData);
        SaveData? LoadGame();
        bool SaveExists();
    }
}