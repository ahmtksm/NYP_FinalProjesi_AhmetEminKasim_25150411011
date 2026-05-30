using AF.Core.Results;
using AF.Entities.Characters;
using AF.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Interfaces
{
    /// <summary>
    /// a service interface that handles the logic for using items, applying their effects, and removing them from the user's inventory [EN]
    /// eşya kullanımı, etkilerinin uygulanması ve kullanıcı envanterinden kaldırılmasını yöneten servis arayüzü [TR]
    /// </summary>
    public interface IItemService
    {
        IResult UseItem(Character user, Character target, IItem item);
    }
}