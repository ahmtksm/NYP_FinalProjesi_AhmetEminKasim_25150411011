using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Core.Results
{
    /// <summary>
    /// Bir işlemin sonucunun türünü temsil eden enum. Bilgi, başarı, hata, hasar, iyileştirme, mana, kritik vuruş ve kaçınma gibi farklı sonuç türlerini içerir.
    /// </summary>
    public enum ResultType
    {
        Info = 0,
        Success = 1,
        Error = 2,
        Warning = 3,
        Damage = 4,
        Heal = 5,
        Mana = 6,
        Critical = 7,
        Dodge = 8
    }
}