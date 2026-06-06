using AF.Business.Abstract;
using AF.Core.Results;
using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Managers
{
    /// <summary>
    /// Saldırı, savunma ve hasar hesaplama gibi dövüş mekaniklerini yöneten servis
    /// </summary>
    public class CombatManager : ICombatService
    {
        private readonly Random random; // Kaçınma ve kritik vuruş hesaplamaları için rastgele değer
        public CombatManager()
        {
            random = new Random();
        }

        // Temel saldırı metodu: Hasar hesaplama, kaçınma ve kritik vuruş kontrolü
        public IResult Attack(Character attacker, Character defender) 
        {
            // Önce her iki karakterin de hayatta olup olmadığı kontrol edilir
            if (!attacker.IsAlive) return new Result(false, $"{attacker.Name} is already dead.", ResultType.Error);
            if (!defender.IsAlive) return new Result(false, $"{defender.Name} is already dead.", ResultType.Error);

            // Kaçınma kontrolü: Eğer savunmacı saldırıyı kaçırırsa, saldırı başarısız olur ve hasar verilmez
            if (CheckDodge(defender)) return new Result(true, $"{defender.Name} dodged the attack.", ResultType.Dodge);

            // Kritik vuruş kontrolü: Eğer saldırgan kritik vuruş yaparsa, hasar iki katına çıkar
            bool critical = CheckCriticalHit(attacker); 

            int damage = CalculateDamage(attacker, defender); // Hasar hesaplama         

            if (critical) damage *= 2; // Kritik vuruş durumunda hasar iki katına çıkar

            // Eğer savunmacı savunma durumundaysa, hasar yarıya düşer ve savunma durumu sıfırlanır
            if (defender.IsDefending) 
            {
                damage /= 2;
                defender.IsDefending = false;
            }

            defender.Health -= damage; // Savunmacının sağlığı hasar kadar azalır
            if (defender.Health < 0) defender.Health = 0; // Sağlık 0'ın altına düşemez

            if (IsDead(defender)) return new Result(true, $"{attacker.Name} has defeated {defender.Name}.", ResultType.Success);
            if (critical) return new Result(true, $"{attacker.Name} landed a critical hit and dealt {damage} damage to {defender.Name}!", ResultType.Critical);
            else return new Result(true, $"{attacker.Name} dealt {damage} damage to {defender.Name}.", ResultType.Damage);
        }       
        public IResult Defend(Character character) // Basit savunma metodu: Bir sonraki tur için savunmayı artırır
        {
            character.IsDefending = true;
            return new Result(true, $"{character.Name} is defending.", ResultType.Success);
        }

        // Hasar hesaplama metodu: Saldırganın hasarından savunmacının savunmasını çıkarır, minimum hasar 1 olarak belirlenir
        public int CalculateDamage(Character attacker, Character defender) 
        {
            int damage = attacker.Stats.Damage - defender.Stats.Defense; // Örneğin, saldırganın Damage değeri 10 ve savunmacının Defense değeri 4 ise, hasar 6 olur
            return Math.Max(1, damage); // Hasar 1'den az olamaz, böylece her saldırı en az 1 hasar verir
        }

        // Kritik vuruşu kontrol eden metod: Saldırganın kritik vuruş şansına göre rastgele bir değer üretilir ve kritik vuruş olup olmadığı belirlenir
        public bool CheckCriticalHit(Character attacker) 
        {
            return random.Next(100) < attacker.Stats.CritChance; // Örneğin, CritChance %20 ise, random.Next(100) 0-99 arasında bir değer üretir ve 20'den küçükse kritik vuruş gerçekleşir
        }

        // Saldırıyı kaçırıp kaçırmadığını kontrol eden metod
        public bool CheckDodge(Character defender) 
        {
            return random.Next(100) < defender.Stats.DodgeChance; // Örneğin, DodgeChance %15 ise, random.Next(100) 0-99 arasında bir değer üretir ve 15'ten küçükse saldırıyı kaçırır
        }

        // Karakterin ölü olup olmadığını kontrol eden metod
        public bool IsDead(Character character) 
        {
            return !character.IsAlive; // Karakterin IsAlive özelliği, Health değeri 0 veya altına düştüğünde false döner
        }
    }
}