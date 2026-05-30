using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Core.Results
{
    /// <summary>
    /// Represents a data operation result with a success flag, a message, and typed data [EN]
    /// Veri işlemin sonucunu, başarı durumu, mesaj ve türleştirilmiş veriyle temsil eder [TR]
    /// </summary>
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }
    }
}