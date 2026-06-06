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
    /// eşya kullanımı, etkilerinin uygulanması ve kullanıcı envanterinden kaldırılmasını yöneten servis arayüzü
    /// </summary>
    public interface IItemService
    {
        IResult UseItem(Character user, Character target, IItem item);
    }
}