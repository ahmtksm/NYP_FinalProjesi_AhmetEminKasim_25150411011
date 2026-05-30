using AF.Entities.Characters.Enemies;
using AF.Entities.Enums;
using AF.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Interfaces
{
    /// <summary>
    /// Service interface for determining enemy actions [EN]
    /// Düşman eylemlerini belirleyen servis'in arayüzü [TR]
    /// </summary>
    public interface IEnemyAIService
    {
        ActionType ChooseAction(Enemy enemy);
        ISkill? ChooseSkill(Enemy enemy);
        IItem? ChooseItem(Enemy enemy);
    }
}