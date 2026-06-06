using AF.Core.Results;
using AF.DataAccess.Abstract;
using AF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AF.DataAccess
{
    /// <summary>
    /// JSON dosyaları kullanarak oyun verilerini kaydetmek ve yüklemek için ISaveRepository arayüzünü uygulayan sınıf
    /// </summary>
    public class SaveRepository : ISaveRepository
    {
        private const string SaveFilePath = "savegame.json"; // Path to the save file

        /// <summary>
        /// Oyun verilerini JSON dosyasına kaydeder
        /// </summary>
        public IResult SaveGame(SaveData saveData)
        {
            try
            {
                string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SaveFilePath, json);
                return new Result(true, "Save Successfull", ResultType.Success);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message, ResultType.Error);
            }
        }

        /// <summary>
        /// Kaydetme dosyasından oyun verilerini yükler, dosya yoksa null döner
        /// </summary>
        public SaveData? LoadGame()
        {
            if (!SaveExists()) return null;
            string json = File.ReadAllText(SaveFilePath);
            return JsonSerializer.Deserialize<SaveData>(json);
        }

        /// <summary>
        /// Kaydetme dosyasının var olup olmadığını kontrol eder
        /// </summary>
        public bool SaveExists()
        {
            return File.Exists(SaveFilePath);
        }
    }
}