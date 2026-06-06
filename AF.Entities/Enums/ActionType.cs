using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;

namespace AF.Entities.Enums
{
    /// <summary>
    /// Defines all possible action types during combat [EN]
    /// Savaş sırasında mümkün olan tüm eylem türlerini tanımlar [TR]
    /// </summary>
    public enum ActionType
    {
        Attack = 0,
        Skill = 1,
        UseItem = 2,
        Defense = 3,
        Skip = 4,
        Save = 5,
        Quit = 6
    }
}