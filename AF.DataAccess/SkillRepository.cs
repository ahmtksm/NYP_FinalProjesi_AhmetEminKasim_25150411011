using AF.Core.Results;
using AF.Entities.Enums;
using AF.Entities.Interfaces;
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
    /// This repository is responsible for creating skill instances based on the provided skill name and retrieving all available skill names [EN]
    /// Bu depo, sağlanan beceri adı temelinde beceri örnekleri oluşturmak ve mevcut tüm beceri adlarını almakla sorumludur [TR]
    /// </summary>
    public class SkillRepository
    {
        // This method creates a skill instance based on the provided skill name [EN]
        // Bu metot, sağlanan beceri adına göre bir beceri oluşturur [TR]
        public IDataResult<ISkill> CreateSkill(SkillName skillName)
        {
            switch (skillName)
            {
                case SkillName.Rage: return new DataResult<ISkill>(true, "Skill created successfully.", new Rage());
                case SkillName.Shield: return new DataResult<ISkill>(true, "Skill created successfully.", new Shield());
                case SkillName.Backstab: return new DataResult<ISkill>(true, "Skill created successfully.", new Backstab());
                case SkillName.BloodSlash: return new DataResult<ISkill>(true, "Skill created successfully.", new BloodSlash());
                case SkillName.Fireball: return new DataResult<ISkill>(true, "Skill created successfully.", new Fireball());
                case SkillName.Burn: return new DataResult<ISkill>(true, "Skill created successfully.", new Burn());
                case SkillName.Freeze: return new DataResult<ISkill>(true, "Skill created successfully.", new Freeze());
                case SkillName.Poison: return new DataResult<ISkill>(true, "Skill created successfully.", new Poison());
                case SkillName.Heal: return new DataResult<ISkill>(true, "Skill created successfully.", new Heal());
                case SkillName.LifeDrain: return new DataResult<ISkill>(true, "Skill created successfully.", new LifeDrain());
                default: return new DataResult<ISkill>(false, "Invalid skill type.", null);
            }
        }
        // This method retrieves all available skill names [EN]
        // Bu metot, mevcut tüm beceri adlarını listeler [TR]
        public List<SkillName> GetAllSkillNames() 
        {
            return Enum.GetValues(typeof(SkillName)).Cast<SkillName>().ToList();
        }
    }
}