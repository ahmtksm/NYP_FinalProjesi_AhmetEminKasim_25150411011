using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Core.Enums
{
    /// <summary>
    /// Defines all possible action types during combat
    /// </summary>
    public enum ActionType
    {
        Attack = 0,
        Skill = 1,
        Skip = 2,
        Defense = 3,
        UseItem = 4
    }
}
