using AF.Business.Interfaces;
using AF.Core.Results;
using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business
{
    /// <summary>
    /// Service responsible for handling combat mechanics such as attacking, defending, and calculating damage [EN]
    /// Saldırı, savunma ve hasar hesaplama gibi dövüş mekaniklerini yöneten servis [TR]
    /// </summary>
    public class CombatService : ICombatService
    {
        // Random instance for dodge and critical hit calculations [EN]
        // Kaçınma ve kritik vuruş hesaplamaları için rastgele değer [TR]
        private readonly Random random;
        public CombatService()
        {
            random = new Random();
        }
        // Basic attack method: Calculate damage, check for dodge and critical hits [EN]
        // Temel saldırı metodu: Hasar hesaplama, kaçınma ve kritik vuruş kontrolü [TR]
        public IResult Attack(Character attacker, Character defender)
        {
            // Checks if both characters are alive before proceeding with the attack [EN]
            // Saldırıya devam etmeden önce her iki karakterin de canlı olup olmadığını kontrol eder [TR]
            if (!attacker.IsAlive) return new ErrorResult($"{attacker.Name} is already dead.");
            if (!defender.IsAlive) return new ErrorResult($"{defender.Name} is already dead.");

            if (CheckDodge(defender)) return new SuccessResult($"{defender.Name} dodged the attack.");

            bool critical = CheckCriticalHit(attacker);
            int damage = CalculateDamage(attacker, defender);         
            
            if (critical) damage *= 2;
            if (defender.IsDefending)
            {
                damage /= 2;
                defender.IsDefending = false;
            }

            defender.Health -= damage;
            if (defender.Health < 0) defender.Health = 0;

            if (IsDead(defender)) return new SuccessResult($"{attacker.Name} has defeated {defender.Name}.");

            return new SuccessResult(critical ? $"{attacker.Name} landed a critical hit and dealt {damage} damage to {defender.Name}!" 
                                              : $"{attacker.Name} dealt {damage} damage to {defender.Name}.");
        }
        // Simple defend method: Increase defense for next turn [EN]
        // Basit savunma metodu: Bir sonraki tur için savunmayı artırır [TR]
        public IResult Defend(Character character)
        {
            character.IsDefending = true;
            return new SuccessResult($"{character.Name} is defending.");
        }
        // Damage calculation method [EN]
        // Hasar hesaplama metodu [TR]
        public int CalculateDamage(Character attacker, Character defender)
        {
            int damage = attacker.Stats.Damage - defender.Stats.Defense; // Damage - Defense [EN] / Hasar - Savunma [TR]
            return Math.Max(1, damage); // Ensure at least 1 damage is dealt [EN] / En az 1 hasar verilir [TR]
        }
        // Checks if the attack is a critical hit based on the attacker's crit chance [EN]
        // Kritik vuruşu kontrol eden metod [TR]
        public bool CheckCriticalHit(Character attacker)
        {
            return random.Next(100) < attacker.Stats.CritChance;
        }
        // Checks if the defender dodges the attack based on their dodge chance [EN]
        // Saldırıyı kaçırıp kaçırmadığını kontrol eden metod [TR]
        public bool CheckDodge(Character defender)
        {
            return random.Next(100) < defender.Stats.DodgeChance;
        }
        // Checks if the character is dead [EN]
        // Karakterin ölü olup olmadığını kontrol eden metod [TR]
        public bool IsDead(Character character)
        {
            return !character.IsAlive;
        }
    }
}