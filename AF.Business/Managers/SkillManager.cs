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
        /// <summary>
        /// Skill kullanma işlemini yöneten yöntem
        /// </summary>
        public IResult UseSkill(Character user, Character target, ISkill skill)
        {
            // Kullanıcı ve hedef karakterin hayatta olup olmadığını kontrol eder
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
            skill.RemainingCooldown = skill.Cooldown; // Becerinin bekletme süresini başlatır

            return new Result(true, $"{user.Name} used {skill.Name} on {target.Name}.", ResultType.Success); // Başarılı bir şekilde beceri kullanıldığını belirten bir sonuç döner
        }

        /// <summary>
        /// Tur sonunda karakterin becerilerinin bekletme sürelerini azaltır
        /// </summary>
        public IResult ReduceCooldowns(Character character)
        {
            foreach (var skill in character.Skills) // Karakterin tüm becerileri üzerinde döner
            {
                if (skill.RemainingCooldown > 0) skill.RemainingCooldown--; // Bekletme süresi 0'dan büyükse, her tur sonunda 1 azaltır
            }

            return new Result(true, "Cooldowns reduced.", ResultType.Success); // Başarılı bir şekilde bekletme sürelerinin azaltıldığını belirten bir sonuç döner
        }

        /// <summary>
        /// Mana kontrolü yapar
        /// </summary>
        public bool HasEnoughMana(Character character, ISkill skill)
        {
            return character.Stats.Mana >= skill.ManaCost; // Karakterin mevcut mana puanlarının becerinin mana maliyetinden büyük veya eşit olduğunu kontrol eder
        }

        /// <summary>
        /// Becerinin bekletme süresini kontrol eder
        /// </summary>
        public bool IsSkillReady(ISkill skill)
        {
            return skill.RemainingCooldown <= 0; // Becerinin bekletme süresinin 0 veya daha az olduğunu kontrol eder
        }

        /// <summary>
        /// Kullanılan becerinin etkisini hedef karaktere uygular
        /// </summary>
        private void ApplySkillEffect(Character user, Character target, ISkill skill)
        {
            int random = Random.Shared.Next(100);
            switch (skill)
            {
                case Rage rage:
                    user.Stats.Damage += rage.DamageBoost; // Kullanıcının hasarını artırır
                    break;
                case Shield shield:
                    user.Stats.Defense += shield.DefenseBoost; // Kullanıcının savunmasını artırır
                    break;
                case Backstab backstab:
                    target.Health -= backstab.Damage; // Hedefe doğrudan hasar verir
                    user.Stats.CritChance += backstab.CritBoost; // Kullanıcının kritik vuruş şansını artırır
                    break;
                case BloodSlash bloodSlash:
                    target.Health -= bloodSlash.Damage; // Hedefe doğrudan hasar verir
                    user.Health -= bloodSlash.SelfDamage; // Kullanıcıya geri hasar verir
                    break;
                case Fireball fireball:
                    target.Health -= fireball.Damage; // Hedefe doğrudan hasar verir
                    if (random < fireball.BurnChance) target.Health -= fireball.Damage / 4; // Rastgele bir yanma hasarı verir
                    break;
                case Burn burn:
                    target.Health -= burn.Damage; // Hedefe doğrudan hasar verir
                    target.Stats.CritChance -= burn.CritChanceReduction; // Hedefin kritik vuruş şansını azaltır
                    break;
                case Freeze freeze:
                    target.Stats.DodgeChance -= freeze.DodgeReduction; // Hedefin kaçınma şansını azaltır
                    break;
                case Poison poison:
                    target.Health -= random / 5; // Rastgele bir zehir hasarı verir
                    break;
                case Heal heal:
                    target.Health += heal.HealAmount; // Hedefin sağlığını iyileştirir
                    if (target.Health > target.MaxHealth) target.Health = target.MaxHealth; // Sağlığın maksimum sağlığı aşmasını engeller
                    break;
                case LifeDrain lifeDrain:
                    target.Health -= lifeDrain.HealTaken; // Hedefe hasar verir
                    user.Health += lifeDrain.HealTaken; // Kullanıcının sağlığını iyileştirir
                    if (user.Health > user.MaxHealth) user.Health = user.MaxHealth; // Sağlığın maksimum sağlığı aşmasını engeller
                    break;
            }
            if (target.Health < 0) target.Health = 0; // Sağlığın 0'ın altına düşmemesini sağlar
        }
    }
}