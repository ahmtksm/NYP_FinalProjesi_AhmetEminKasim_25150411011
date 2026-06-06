using AF.Business.Abstract;
using AF.Core;
using AF.Core.Results;
using AF.Entities;
using AF.Entities.Abstract;
using AF.Entities.Characters.Enemies;
using AF.Entities.Characters.Players;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.UI
{
    /// <summary>
    /// Bu sınıf, konsol üzerinden tüm kullanıcı etkileşimlerini yönetmekle sorumludur
    /// </summary>
    public class ConsoleUI
    {
        private readonly IGameService _gameManager;
        public ConsoleUI(IGameService gameManager)
        {
            _gameManager = gameManager;
        }

        // Ana oyun döngüsü
        public void Run()
        {
            while (true) { ShowMainmenu(); }
        }

        // Ana menüyü gösterir ve kullanıcı seçimini yönetir
        private void ShowMainmenu()
        {
            Console.CursorVisible = false;
            List<string> options = new List<string> { "New Game", "Load Game", "Exit" };
            int choice = ConsoleInput.NavigateMenu(() => { ColorText.Title("=== Arena Fighter ==="); ColorText.Seperator(); }, options);
            switch (choice)
            {
                case 0:
                    StartNewGame();
                    break;
                case 1:
                    LoadGame();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }

        // Yeni bir oyun başlatır, bir oyuncu ve bir düşman oluşturur, ardından savaşı başlatır
        private void StartNewGame()
        {
            Console.Clear();

            string playerName = ConsoleInput.GetString("Enter your name: "); // Oyuncu adını alır
            List<string> options = Enum.GetValues<PlayerType>().Select(t => t.ToString()).ToList(); // Oyuncu sınıfı seçeneklerini oluşturur
            int choice = ConsoleInput.NavigateMenu(() => { ColorText.Info("=== Select your character ==="); ColorText.Seperator(); }, options); // Oyuncu sınıfı seçimini alır
            PlayerType selectedType = (PlayerType)(choice);

            var playerResult = _gameManager.NewGame(selectedType, playerName);
            if (!playerResult.Success) // Oyuncu oluşturulamazsa hata mesajı
            {
                ColorText.Error(playerResult.Message);
                ConsoleInput.PressAnyKey();
                return;
            }
            Player player = playerResult.Data;

            var enemyResult = _gameManager.GenerateRandomEnemy();
            if (!enemyResult.Success) // Düşman oluşturulamazsa hata mesajı
            {
                ColorText.Error(enemyResult.Message);
                ConsoleInput.PressAnyKey();
                return;
            }

            StartBattle(player, enemyResult.Data); // Savaşı başlat
        }

        // Kaydedilmiş bir oyunu yükler ve yüklenen oyuncu ile yeni bir düşmanla savaşı başlatır
        private void LoadGame()
        {
            var result = _gameManager.LoadGame();
            if (!result.Success)
            {
                ColorText.Error(result.Message);
                ConsoleInput.PressAnyKey();
                return;
            }

            GameState gameState = result.Data;
            Player player = gameState.Player;
            Enemy enemy = gameState.Enemy;
            StartBattle(gameState.Player, gameState.Enemy);
        }

        // Oyuncu ve düşman arasındaki savaş döngüsünü yönetir, oyuncu eylemlerini ve düşman tepkilerini işler, savaş bitene kadar devam eder
        private void StartBattle(Player player, Enemy enemy)
        {
            while (!_gameManager.IsBattleOver(player, enemy))
            {
                ActionType action = ShowBattleMenu(player, enemy);
                IResult result;

                switch (action) // Oyuncu seçimine göre eylemi işler
                {
                    case ActionType.Attack:
                        result = _gameManager.ProcessPlayerAction(action, player, enemy);
                        break;
                    case ActionType.Skill:
                        ISkill? skill = SelectSkill(player, enemy);
                        if (skill == null) continue;
                        result = _gameManager.ProcessPlayerAction(action, player, enemy, skill, null);
                        break;
                    case ActionType.UseItem:
                        IItem? item = SelectItem(player, enemy);
                        if (item == null) continue;
                        result = _gameManager.ProcessPlayerAction(action, player, enemy, null, item);
                        break;
                    case ActionType.Defense:
                        result = _gameManager.ProcessPlayerAction(action, player, enemy);
                        break;
                    case ActionType.Skip:
                        if (!ConsoleInput.GetConfirmation("Are you sure you want to skip your turn?")) continue;
                        result = new Result(true, "You skipped your turn.", ResultType.Success);
                        break;
                    case ActionType.Save:
                        if (!ConsoleInput.GetConfirmation("Do you want to save the game?")) continue;
                        result = _gameManager.SaveGame(player, enemy);
                        ShowResult(result);
                        continue;
                    case ActionType.Quit:
                        if (!ConsoleInput.GetConfirmation("Are you sure you want to quit the game? Unsaved progress will be lost.")) continue;
                        return;
                    default:
                        continue;
                }

                ShowResult(result);
                if (_gameManager.IsBattleOver(player, enemy)) break;

                result = _gameManager.ProcessEnemyAction(player, enemy);
                ShowResult(result);
            }

            if (player.IsAlive) ShowVictory();
            else ShowDefeat();
        }

        // Oyuncu ve düşman bilgileriyle savaş ekranını çizer
        private void DrawBattleHeader(Player player, Enemy enemy)
        {
            ShowPlayerInfo(player);
            ShowEnemyInfo(enemy);
            ColorText.Seperator();
        }

        // Savaş menüsünü gösterir, oyuncu ve düşman bilgilerini gösterir ve oyuncunun eylem seçimini alır
        private ActionType ShowBattleMenu(Player player, Enemy enemy)
        {
            List<string> options = new List<string> { "Attack", "Use Skill", "Use Item", "Defend", "Skip Turn", "Save Game", "Quit Game" };

            int choice = ConsoleInput.NavigateMenu(() => DrawBattleHeader(player, enemy), options);
            ColorText.Seperator();
            switch (choice) // Oyuncu seçimine göre eylemi döndürür
            {
                case 0: return ActionType.Attack;
                case 1: return ActionType.Skill;
                case 2: return ActionType.UseItem;
                case 3: return ActionType.Defense;
                case 4: return ActionType.Skip;
                case 5: return ActionType.Save;
                case 6: return ActionType.Quit;
                default: return ActionType.Skip;
            }
        }

        // Oyuncunun mevcut becerilerinden birini seçmesi için bir menü gösterir
        private ISkill? SelectSkill(Player player, Enemy enemy)
        {
            if (player.Skills.Count == 0) // Eğer oyuncunun becerisi yoksa hata mesajı gösterir ve boş döndürür
            {
                ColorText.Error("No skills available.");
                ConsoleInput.PressAnyKey();
                return null;
            }

            List<string> options = player.Skills.Select(s => $"{s.Name} | {s.Description} | Mana: {s.ManaCost} | Cooldown: {s.RemainingCooldown}").ToList();
            options.Add("Back");
            int choice = ConsoleInput.NavigateMenu(() => DrawBattleHeader(player, enemy), options);
            if (choice == options.Count - 1) return null;
            return player.Skills[choice];
        }

        // Oyuncunun envanterinden bir öğe seçmesi için bir menü gösterir
        private IItem? SelectItem(Player player, Enemy enemy)
        {
            if (player.Inventory.Count == 0) // Eğer oyuncunun envanterinde öğe yoksa hata mesajı gösterir ve boş döndürür
            {
                ColorText.Error("No items available.");
                ConsoleInput.PressAnyKey();
                return null;
            }

            List<string> options = player.Inventory.Select(i => $"{i.Name} | {i.Description}").ToList();
            options.Add("Back");
            int choice = ConsoleInput.NavigateMenu(() => DrawBattleHeader(player, enemy), options);
            if (choice == options.Count - 1) return null;
            return player.Inventory[choice];
        }

        // Oyuncu bilgilerini gösterir
        private void ShowPlayerInfo(Player player)
        {
            ColorText.Info($"Player: {player.Name} | HP: {player.Health}/{player.MaxHealth} | Mana: {player.Stats.Mana}");
        }

        // Düşman bilgilerini gösterir
        private void ShowEnemyInfo(Enemy enemy)
        {
            ColorText.Warning($"Enemy: {enemy.Name} | HP: {enemy.Health}/{enemy.MaxHealth}");
        }

        // Savaş sonucu mesajını gösterir
        private void ShowResult(IResult result)
        {
            switch (result.ResultType)
            {
                case ResultType.Info:
                    ColorText.Info(result.Message);
                    break;
                case ResultType.Success:
                    ColorText.Success(result.Message);
                    break;
                case ResultType.Error:
                    ColorText.Error(result.Message);
                    break;
                case ResultType.Warning:
                    ColorText.Warning(result.Message);
                    break;
                case ResultType.Damage:
                    ColorText.Damage(result.Message);
                    break;
                case ResultType.Heal:
                    ColorText.Heal(result.Message);
                    break;
                case ResultType.Mana:
                    ColorText.Mana(result.Message);
                    break;
                case ResultType.Critical:
                    ColorText.Critical(result.Message);
                    break;
                case ResultType.Dodge:
                    ColorText.Dodge(result.Message);
                    break;
            }
            ConsoleInput.PressAnyKey();
            ColorText.Seperator();
        }

        // Zafer ekranını gösterir
        private void ShowVictory()
        {
            Console.Clear();
            ColorText.Title("=== Victory ===");
            ColorText.Seperator();
            ColorText.Success("Congratulations! You have defeated the enemy!");
            ColorText.Seperator();
            ConsoleInput.PressAnyKey();
        }

        // Yenilgi ekranını gösterir
        private void ShowDefeat()
        {
            Console.Clear();
            ColorText.Title("=== Defeat ===");
            ColorText.Seperator(); 
            ColorText.Error("Better luck next time!");
            ColorText.Seperator();
            ConsoleInput.PressAnyKey();
        }
    }
}