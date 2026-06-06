using AF.Entities.Characters.Enemies;
using AF.Entities.Enums;
using AF.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Abstract
{
    /// <summary>
    /// Düşman eylemlerini belirleyen servis'in arayüzü
    /// </summary>
    public interface IEnemyAIService
    {
        ActionType ChooseAction(Enemy enemy);
        ISkill? ChooseSkill(Enemy enemy);
        IItem? ChooseItem(Enemy enemy);
    }
}