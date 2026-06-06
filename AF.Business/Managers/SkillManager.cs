using AF.Business.Abstract;
using AF.Core;
using AF.Core.Results;
using AF.Entities;
using AF.Entities.Characters;
using AF.Entities.Abstract;
using AF.Entities.Skills.SkillTypes.Buff;
using AF.Entities.Skills.SkillTypes.Damage;
using AF.Entities.Skills.SkillTypes.Debuff;
using AF.Entities.Skills.SkillTypes.Heal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Managers
{
    /// <summary>
    /// beceri kullanımı, mana kontrolü ve bekletme süresini yöneten servis
    /// </summary>
    public class SkillManager : ISkillService
    {
        // Skill kullanma işlemini yöneten yöntem
        public IResult UseSkill(Character user, Character target, ISkill skill) 
        {
            // Beceriyi kullanma işlemine devam etmeden önce her iki karakterin de canlı olup olmadığını kontrol eder
            if (!user.IsAlive) return new Result(false, $"{user.Name} is dead and cannot use skills.", ResultType.Error);
            if (!target.IsAlive) return new Result(false, $"{target.Name} is already dead.", ResultType.Error);

            // Kullanıcının beceriyi kullanmak için yeterli manaya sahip olup olmadığını kontrol eder
            if (!HasEnoughMana(user, skill)) return new Result(false, "Not Enough Mana.", ResultType.Error);

            // Beceri bekletme süresini kontrol eder
            if (!IsSkillReady(skill)) return new Result(false, "Skill is on cooldown.", ResultType.Error);

            // Kullanıcının beceri listesinde bu beceriye sahip olup olmadığını kontrol eder
            if (!user.Skills.Contains(skill)) return new Result(false, "Skill not found.", ResultType.Error);

            user.Stats.Mana -= skill.ManaCost; // Becerinin mana maliyetini kullanıcıdan düşer
            ApplySkillEffect(user, target, skill); // Becerinin etkisini hedef karaktere uygular
            skill.RemainingCooldown = skill.Cooldown;

            return new Result(true, $"{user.Name} used {skill.Name} on {target.Name}.", ResultType.Success);
        }

        // Tur sonunda karakterin becerilerinin bekletme sürelerini azaltır
        public IResult ReduceCooldowns(Character character) 
        {
            foreach (var skill in character.Skills)
            {
                if (skill.RemainingCooldown > 0) skill.RemainingCooldown--;
            }

            return new Result(true, "Cooldowns reduced.", ResultType.Success);
        }

        // Mana kontrolü yapar
        public bool HasEnoughMana(Character character, ISkill skill) 
        {
            return character.Stats.Mana >= skill.ManaCost;
        }

        // Becerinin bekletme süresini kontrol eder
        public bool IsSkillReady(ISkill skill) 
        {
            return skill.RemainingCooldown <= 0;
        }

        // Kullanılan becerinin etkisini hedef karaktere uygular
        private void ApplySkillEffect(Character user, Character target, ISkill skill) 
        {
            switch (skill)
            {
                case Rage rage:
                    user.Stats.Damage += rage.DamageBoost;
                    break;
                case Shield shield:
                    user.Stats.Defense += shield.DefenseBoost;
                    break;
                case Backstab backstab:
                    target.Health -= backstab.Damage;
                    break;
                case BloodSlash bloodSlash:
                    target.Health -= bloodSlash.Damage;
                    break;
                case Fireball fireball:
                    target.Health -= fireball.Damage;
                    break;
                case Burn burn:
                    target.Health -= burn.Damage;
                    break;
                case Freeze freeze:
                    target.Stats.Speed -= Math.Max(0, freeze.SpeedReduction);
                    break;
                case Poison poison:
                    target.Health -= poison.Damage;
                    break;
                case Heal heal:
                    target.Health += heal.HealAmount;
                    if (target.Health > target.MaxHealth) target.Health = target.MaxHealth;
                    break;
                case LifeDrain lifeDrain:
                    target.Health -= lifeDrain.Damage;
                    user.Health += lifeDrain.HealAmount;
                    if (user.Health > user.MaxHealth) user.Health = user.MaxHealth;
                    break;
            }
            if (target.Health < 0) target.Health = 0; // Sağlığın 0'ın altına düşmemesini sağlar
        }
    }
}