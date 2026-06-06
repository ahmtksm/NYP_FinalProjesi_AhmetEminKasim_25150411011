using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.UI
{
    /// <summary>
    /// Konsoldan kullanıcı girdisi almak için metotlar sağlar.
    /// </summary>
    public static class ConsoleInput
    {
        // Kullanıcının ok tuşlarıyla gezinerek bir seçenek seçmesini sağlar
        public static int NavigateMenu(Action drawHeader, List<string> options) 
        {
            int index = 0;

            while (true)
            {
                Console.Clear();
                drawHeader();
                for (int i = 0; i < options.Count; i++)
                {
                    if (i == index) ColorText.Success($"> {options[i]}");
                    else ColorText.WriteLine($"  {options[i]}", ConsoleColor.White);
                }

                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        index--;
                        if (index < 0) index = options.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        index++;
                        if (index >= options.Count) index = 0;
                        break;
                    case ConsoleKey.Enter:
                        return index;
                }
            }
        }

        // Kullanıcıdan boş olmayan bir string girişi alır
        public static string GetString(string message) 
        {
            while (true)
            {
                ColorText.Write(message, ConsoleColor.White);
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input)) return input.Trim();
                ColorText.Error("Input cannot be empty. Please try again.");
            }
        }

        // Kullanıcıdan evet/hayır onayı alır
        public static bool GetConfirmation(string message) 
        {
            Console.WriteLine();

            ColorText.Info($"{message} (Y/N): ");

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                }
            }
        }

        // Devam etmeden önce kullanıcıdan herhangi bir tuşa basmasını bekler
        public static void PressAnyKey() 
        {
            ColorText.Info("Press any key to continue...");
            Console.ReadKey();
        }
    }
}