using AF.Core.Results;
using AF.Entities.Characters;
using AF.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Abstract
{
    /// <summary>
    /// beceri kullanımı, mana kontrolü ve bekletme süresini yöneten servis arayüzü
    /// </summary>
    public interface ISkillService
    {
        IResult UseSkill(Character user, Character target, ISkill skill);
        IResult ReduceCooldowns(Character character);
        bool HasEnoughMana(Character character, ISkill skill);
        bool IsSkillReady(ISkill skill);
    }
}