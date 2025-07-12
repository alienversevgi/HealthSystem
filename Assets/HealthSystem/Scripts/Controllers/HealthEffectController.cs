using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using EventBus;
using UnityEngine.Events;

namespace Game.HealthSystem
{
    public class HealthEffectController
    {
        private HealthController _health;
        private Dictionary<OverTimeEffectType, OverTimeEffect> _overTimeEffects;

        public List<BaseBuff> Buffs { get; private set; }
        public List<BaseDebuff> Debuffs { get; private set; }

        public UnityEvent<HealthEffectEvent.OverTimeAdded> OnOverTimeAdded;
        public UnityEvent<HealthEffectEvent.OverTimeRemoved> OnOverTimeRemoved;
        
        public void Initialize(HealthController health)
        {
            _health = health;
            _overTimeEffects = new Dictionary<OverTimeEffectType, OverTimeEffect>();
            Buffs = new List<BaseBuff>();
            Debuffs = new List<BaseDebuff>();
            OnOverTimeAdded = new UnityEvent<HealthEffectEvent.OverTimeAdded>();
            OnOverTimeRemoved = new UnityEvent<HealthEffectEvent.OverTimeRemoved>();
        }

        public void AddOverTimeEffect(OverTimeEffect overTimeEffect)
        {
            overTimeEffect.Initialize(_health);
            overTimeEffect.OverTimeCompleted.AddListener((eventData) => RemoveOverTimeEffect(overTimeEffect));
            overTimeEffect.Apply().Forget();
            
            _overTimeEffects.Add(overTimeEffect.GetOverTimeType(), overTimeEffect);
            
            OnOverTimeAdded?.Invoke(new HealthEffectEvent.OverTimeAdded()
            {
                EffectType = overTimeEffect.GetOverTimeType()
            });
        }

        public void RemoveOverTimeEffect(OverTimeEffect overTimeEffect)
        {
            overTimeEffect.Reset();
            _overTimeEffects.Remove(overTimeEffect.GetOverTimeType());
            
            OnOverTimeRemoved?.Invoke(new HealthEffectEvent.OverTimeRemoved()
            {
                EffectType = overTimeEffect.GetOverTimeType()
            });
        }

        public OverTimeEffect GetOverTimeEffect(OverTimeEffectType type)
        {
            if (_overTimeEffects.ContainsKey(type))
                return _overTimeEffects[type];

            return null;
        }

        public void AddBuff(BaseBuff buff)
        {
            buff.Initialize(_health);
            buff.Apply().Forget();
            Buffs.Add(buff);
        }

        public void RemoveBuff(BaseBuff buff)
        {
            buff.Reset();
            Buffs.Remove(buff);
        }

        public void AddDebuff(BaseDebuff debuff)
        {
            debuff.Initialize(_health);
            debuff.Apply().Forget();
            Debuffs.Add(debuff);
        }

        public void RemoveDebuff(BaseDebuff debuff)
        {
            debuff.Reset();
            Debuffs.Remove(debuff);
        }

        public float CheckPreHealEffect(float healingAmount)
        {
            return HealingStatusEffectApply(healingAmount);
        }

        public float CheckPreDamageEffect(float damageAmount)
        {
            return DamageStatusEffectApply(damageAmount);
        }

        private float HealingStatusEffectApply(float healingAmount)
        {
            for (int i = 0; i < Buffs.Count; i++)
            {
                healingAmount = Buffs[i].CheckPreHealingEffect(healingAmount);
            }

            return healingAmount;
        }

        private float DamageStatusEffectApply(float damageAmount)
        {
            for (int i = 0; i < Buffs.Count; i++)
            {
                damageAmount = Buffs[i].CheckPreDamageEffect(damageAmount);
            }

            return damageAmount;
        }
    }
}