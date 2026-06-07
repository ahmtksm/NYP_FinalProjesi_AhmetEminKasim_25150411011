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
        /// <summary>
        /// Yazıyı belirtilen renkte yeni satır olmadan yazar
        /// </summary>
        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Yazıyı belirtilen renkte yeni satır ile yazar
        /// </summary>
        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Ayırıcı çizgi için metot
        /// </summary>
        public static void Seperator() 
        { 
            WriteLine(new string('-', 50), ConsoleColor.DarkGray); 
        }

        /// <summary>
        /// Başlıklar için metot
        /// </summary>
        public static void Title(string text, int lenght)
        {
            WriteLine(new string('=', lenght), ConsoleColor.DarkCyan);
            WriteLine(text, ConsoleColor.DarkCyan);
            WriteLine(new string('=', lenght), ConsoleColor.DarkCyan);
        }

        public static void Info(string text) { WriteLine(text, ConsoleColor.Gray); } /// Bilgilendirici mesajı gri renkte yazar
        public static void Success(string text) { WriteLine(text, ConsoleColor.Green); } /// Başarı mesajını yeşil renkte yazar
        public static void Error(string text) { WriteLine(text, ConsoleColor.Red); } /// Hata mesajını kırmızı renkte yazar
        public static void Warning(string text) { WriteLine(text, ConsoleColor.Yellow); } /// Uyarı mesajını sarı renkte yazar   
        
        public static void Damage(string text) { WriteLine(text, ConsoleColor.Red); } /// Hasar mesajını kırmızı renkte yazar
        public static void Heal(string text) { WriteLine(text, ConsoleColor.DarkGreen); } /// İyileştirme mesajını koyu yeşil renkte yazar
        public static void Mana(string text) { WriteLine(text, ConsoleColor.DarkMagenta); } /// Mana mesajını magenta renkte yazar
        public static void Critical(string text) { WriteLine(text, ConsoleColor.DarkRed); } /// Kritik vuruş mesajını koyu kırmızı renkte yazar
        public static void Dodge(string text) { WriteLine(text, ConsoleColor.Blue); } /// Kaçırma mesajını mavi renkte yazar
    }
}