using AF.Core.Results;
using AF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DataAccess.Abstract
{
    /// <summary>
    /// Oyun verilerini kaydetmek ve yüklemek için depo
    /// </summary>
    public interface ISaveRepository
    {
        IResult SaveGame(SaveData saveData);
        SaveData? LoadGame();
        bool SaveExists();
    }
}