using AF.Core.Results;
using AF.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Interfaces
{
    /// <summary>
    /// Service interface responsible for handling combat mechanics such as attacking, defending, and calculating damage [EN]
    /// Saldırı, savunma ve hasar hesaplama gibi dövüş mekaniklerini yöneten servis'in arayüzü [TR]
    /// </summary>
    public interface ICombatService
    {
        IResult Attack(Character attacker, Character defender);
        IResult Defend(Character character);
        int CalculateDamage(Character attacker, Character defender);       
        bool CheckCriticalHit(Character attacker);
        bool CheckDodge(Character defender);
        bool IsDead(Character character);
    }
}