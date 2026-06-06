using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Core.Results
{
    /// <summary>
    /// Bir temel işlemin sonucunu, başarı durumu ve mesajıyla temsil eder
    /// </summary>
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        public ResultType ResultType { get; }
    }
}