using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.UI
{
    /// <summary>
    /// Renkli metinleri konsola yazmak için metotlar sağlar
    /// </summary>
    public static class ColorText
    {
        // Yazıyı belirtilen renkte yeni satır olmadan yazar
        public static void Write(string text, ConsoleColor color) 
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        // Yazıyı belirtilen renkte yeni satır ile yazar
        public static void WriteLine(string text, ConsoleColor color) 
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void Seperator() { WriteLine(new string('-', 50), ConsoleColor.DarkGray); } // Koyu gri renkte ayırıcı çizgi yazar
        public static void Title(string text) { WriteLine(text, ConsoleColor.Magenta); } // Başlığı magenta renkte yazar
        public static void Info(string text) { WriteLine(text, ConsoleColor.Gray); } // Bilgilendirici mesajı gri renkte yazar
        public static void Success(string text) { WriteLine(text, ConsoleColor.Green); } // Başarı mesajını yeşil renkte yazar
        public static void Error(string text) { WriteLine(text, ConsoleColor.Red); } // Hata mesajını kırmızı renkte yazar
        public static void Warning(string text) { WriteLine(text, ConsoleColor.Yellow); } // Uyarı mesajını sarı renkte yazar        
        public static void Damage(string text) { WriteLine(text, ConsoleColor.DarkRed); } // Hasar mesajını koyu kırmızı renkte yazar
        public static void Heal(string text) { WriteLine(text, ConsoleColor.DarkGreen); } // İyileştirme mesajını koyu yeşil renkte yazar
        public static void Mana(string text) { WriteLine(text, ConsoleColor.Blue); } // Mana mesajını mavi renkte yazar
        public static void Critical(string text) { WriteLine(text, ConsoleColor.Red); } // Kritik vuruş mesajını kırmızı renkte yazar
        public static void Dodge(string text) { WriteLine(text, ConsoleColor.Cyan); } // Kaçırma mesajını koyu cyan renkte yazar
    }
}