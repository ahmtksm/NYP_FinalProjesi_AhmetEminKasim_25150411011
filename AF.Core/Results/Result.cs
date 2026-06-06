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
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }
        public ResultType ResultType { get; }
        public Result(bool success, string message, ResultType resultType)
        {
            Success = success;
            Message = message;
            ResultType = resultType;
        }
    }
}