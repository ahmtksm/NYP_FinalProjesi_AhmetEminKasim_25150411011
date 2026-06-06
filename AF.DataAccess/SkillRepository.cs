using AF.Core.Results;
using AF.Entities.Enums;
using AF.Entities.Abstract;
using AF.Entities.Skills;
using AF.Entities.Skills.SkillTypes.Buff;
using AF.Entities.Skills.SkillTypes.Damage;
using AF.Entities.Skills.SkillTypes.Debuff;
using AF.Entities.Skills.SkillTypes.Heal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DataAccess
{
    /// <summary>
    /// Bu depo, sağlanan beceri adı temelinde beceri örnekleri oluşturmak ve mevcut tüm beceri adlarını almakla sorumludur
    /// </summary>
    public class SkillRepository
    {
        /// <summary>
        /// Bu metot, sağlanan beceri adına göre bir beceri oluşturur
        /// </summary>
        public IDataResult<ISkill> CreateSkill(SkillName skillName)
        {
            switch (skillName)
            {
                case SkillName.Rage: 
                    return new DataResult<ISkill>(true, "Rage skill created successfully.", new Rage());
                case SkillName.Shield: 
                    return new DataResult<ISkill>(true, "Shield skill created successfully.", new Shield());
                case SkillName.Backstab: 
                    return new DataResult<ISkill>(true, "Backstab skill created successfully.", new Backstab());
                case SkillName.BloodSlash: 
                    return new DataResult<ISkill>(true, "BloodSlash skill created successfully.", new BloodSlash());
                case SkillName.Fireball: 
                    return new DataResult<ISkill>(true, "Fireball skill created successfully.", new Fireball());
                case SkillName.Burn: 
                    return new DataResult<ISkill>(true, "Burn skill created successfully.", new Burn());
                case SkillName.Freeze: 
                    return new DataResult<ISkill>(true, "Freeze skill created successfully.", new Freeze());
                case SkillName.Poison: 
                    return new DataResult<ISkill>(true, "Poison skill created successfully.", new Poison());
                case SkillName.Heal:
                    return new DataResult<ISkill>(true, "Heal skill created successfully.", new Heal());
                case SkillName.LifeDrain: 
                    return new DataResult<ISkill>(true, "Life Drain skill created successfully.", new LifeDrain());
                default: 
                    return new DataResult<ISkill>(false, "Invalid skill type.", null);
            }
        }
    }
}