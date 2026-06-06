using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Core.Results
{
    /// <summary>
    /// Veri işlemin sonucunu, başarı durumu, mesaj ve türleştirilmiş veriyle temsil eder
    /// </summary>
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}