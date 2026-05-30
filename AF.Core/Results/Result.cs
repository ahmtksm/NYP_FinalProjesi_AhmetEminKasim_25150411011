using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Core.Results
{
    /// <summary>
    /// Represents a basic operation result with a success status and a message [EN]
    /// Bir temel işlemin sonucunu, başarı durumu ve mesajıyla temsil eder [TR]
    /// </summary>
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public Result(bool success) : this(success, "")
        {

        }
    }
    /// <summary>
    /// Represents a successful operation result with an optional message [EN]
    /// Başarılı bir işlemin sonucunu, isteğe bağlı bir mesajla temsil eder [TR]
    /// </summary>
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true, "")
        {

        }
        public SuccessResult(string message) : base(true, message)
        {

        }
    }
    /// <summary>
    /// Represents an error operation result with an optional message [EN]
    /// Başarısız bir işlemin sonucunu, isteğe bağlı bir mesajla temsil eder [TR]
    /// </summary>
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false, "")
        {

        }
        public ErrorResult(string message) : base(false, message)
        {

        }
    }
}