using AF.Entities.Characters;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Entities.Skills.SkillTypes.Debuff
{
    /// <summary>
    /// Düşmanı yavaşlatır ve kaçınma şansını azaltır
    /// </summary>
    public class Freeze : Skill
    {
        public int DodgeReduction { get; private set; } // Hedef donarken uygulanan kaçınma azaltma miktarı

        public Freeze() : base("Freeze", "Reduces the target's dodge chance", 5, 25, SkillType.Debuff, SkillName.Freeze)
        {
            DodgeReduction = 10;
        }
    }
}