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
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}