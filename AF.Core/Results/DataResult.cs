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
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(bool success, string message, T data) : base(success, message, ResultType.Info)
        {
            Data = data;
        }
    }
}