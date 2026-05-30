using AF.Business.Interfaces;
using AF.Core;
using AF.Core.Results;
using AF.Entities;
using AF.Entities.Characters;
using AF.Entities.Interfaces;
using AF.Entities.Skills.SkillTypes.Buff;
using AF.Entities.Skills.SkillTypes.Damage;
using AF.Entities.Skills.SkillTypes.Debuff;
using AF.Entities.Skills.SkillTypes.Heal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business
{
    /// <summary>
    /// a skill service that handles the logic for using skills, checking mana, and managing cooldowns [EN]
    /// beceri kullanımı, mana kontrolü ve bekletme süresini yöneten servis [TR]
    /// </summary>
    public class SkillService : ISkillService
    {
        // This method allows a character to use a skill on a target character, checking for mana, cooldowns, and applying the skill's effect [EN]
        // Bu yöntem, bir karakterin bir hedef karaktere beceri kullanmasına izin verir, mana, bekletme süreleri kontrol eder ve becerinin etkisini uygular [TR]
        public IResult UseSkill(Character user, Character target, ISkill skill)
        {
            // Checks if both characters are alive before proceeding with the skill use [EN]
            // Beceriyi kullanma işlemine devam etmeden önce her iki karakterin de canlı olup olmadığını kontrol eder [TR]
            if (!user.IsAlive) return new ErrorResult($"{user.Name} is dead and cannot use skills.");
            if (!target.IsAlive) return new ErrorResult($"{target.Name} is already dead.");

            // Checks if the user has enough mana to use the skill [EN]
            // Kullanıcının beceriyi kullanmak için yeterli manaya sahip olup olmadığını kontrol eder [TR]
            if (!HasEnoughMana(user, skill)) return new ErrorResult("Not Enough Mana.");

            // Checks if the skill is off cooldown and ready to be used [EN]
            // Beceri bekletme süresini kontrol eder [TR]
            if (!IsSkillReady(skill)) return new ErrorResult("Skill is on cooldown.");

            // Checks if the user has the skill in their skill list [EN]
            // Kullanıcının beceri listesinde bu beceriye sahip olup olmadığını kontrol eder [TR]
            if (!user.Skills.Contains(skill)) return new ErrorResult("Skill not found.");

            user.Stats.Mana -= skill.ManaCost;
            ApplySkillEffect(user, target, skill);
            skill.RemainingCooldown = skill.Cooldown;

            return new SuccessResult($"{user.Name} used {skill.Name} on {target.Name}.");
        }
        // This method reduces the cooldowns of used skill by 1 on each turn [EN]
        // Bu yöntem, her turun sonunda bir karakterin kullanılmış becerilerinin bekletme sürelerini 1 azaltır [TR]
        public IResult ReduceCooldowns(Character character)
        {
            foreach (var skill in character.Skills)
            {
                if (skill.RemainingCooldown > 0) skill.RemainingCooldown--;
            }

            return new SuccessResult();
        }
        // This method checks if the character has enough mana to use a skill [EN]
        // Bu yöntem, karakterin bir beceriyi kullanması için yeterli manaya sahip olup olmadığını kontrol eder [TR]
        public bool HasEnoughMana(Character character, ISkill skill)
        {
            return character.Stats.Mana >= skill.ManaCost;
        }
        // This method checks if the skill is off cooldown and ready to be used [EN]
        // Bu yöntem, becerinin bekletme süresini kontrol eder [TR]
        public bool IsSkillReady(ISkill skill)
        {
            return skill.RemainingCooldown <= 0;
        }
        // This method applies the effect of the skill to the target character based on the type of skill used [EN]
        // Bu yöntem, kullanılan beceri türüne göre becerinin etkisini hedef karaktere uygular [TR]
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
            if (target.Health < 0) target.Health = 0; // Ensures health does not drop below 0 [EN] / Sağlığın 0'ın altına düşmemesini sağlar [TR]
        }
    }
}