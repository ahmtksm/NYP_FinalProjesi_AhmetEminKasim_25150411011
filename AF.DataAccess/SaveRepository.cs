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
    /// Implements the ISaveRepository interface to handle saving and loading game data using JSON files [EN]
    /// JSON dosyaları kullanarak oyun verilerini kaydetmek ve yüklemek için ISaveRepository arayüzünü uygulayan sınıf [TR]
    /// </summary>
    public class SaveRepository : ISaveRepository
    {
        private const string SaveFilePath = "savegame.json"; // Path to the save file
        // Saves the game data to a JSON file [EN]
        // Oyun verilerini JSON dosyasına kaydeder [TR]
        public void SaveGame(SaveData saveData)
        {
            string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SaveFilePath, json);
        }
        // Loads the game data from the save file, returns null if the file doesn't exist [EN]
        // Kaydetme dosyasından oyun verilerini yükler, dosya yoksa null döner [TR]
        public SaveData? LoadGame()
        {
            if (!SaveExists()) return null;
            string json = File.ReadAllText(SaveFilePath);
            return JsonSerializer.Deserialize<SaveData>(json);
        }
        // Checks if the save file exists [EN]
        // Kaydetme dosyasının var olup olmadığını kontrol eder [TR]
        public bool SaveExists()
        {
            return File.Exists(SaveFilePath);
        }
    }
}