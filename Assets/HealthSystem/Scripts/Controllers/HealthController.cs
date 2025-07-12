using System;
using EventBus;
using Game.HealthSystem.Interfaces;
using UnityEngine;

namespace Game.HealthSystem
{
    public class HealthController : IDisposable
    {
        public Resistance Resistance { get; private set; }
        public HealthEffectController Effect { get; private set; }

        public float Current
        {
            get
            {
                lock (_currentLock)
                    return _current;
            }
            private set
            {
                lock (_currentLock)
                {
                    _current = value;
                    OnHealthChanged?.Invoke(Current);
                }
            }
        }

        public float Max
        {
            get
            {
                lock (_maxLock)
                    return _max;
            }
            private set
            {
                lock (_maxLock)
                    _max = value;
            }
        }

        public bool IsFulled => Current >= Max;
        public bool IsDead => Current <= 0;

        private float _current;
        private readonly object _currentLock = new object();

        private float _max;
        private readonly object _maxLock = new object();
        
        private BaseDamageCalculationStrategy _baseDamageCalculationStrategy;

        public float GetCurrent() => Current;
        public float GetMax() => Max;

        public Resistance GetResistance() => Resistance;

        public event Action<float> OnHealthChanged;
        public event Action OnDeath;

        public void Initialize(HealthData data)
        {
            Current = data.Health;
            Max = data.MaxHealth;
            Resistance = data.Resistance;
            SetDamageCalculationStrategy(data.DamageCalculationStrategy);
            
            Effect = new HealthEffectController();
            Effect.Initialize(this);
        }

        public void ApplyHeal(float amount)
        {
            amount = Effect.CheckPreHealEffect(amount);
            Current = Mathf.Clamp(Current + amount, 0, Max);

            Debug.Log($"-{amount} heal applied. CurrentHp : {Current}");
        }

        public void ApplyDamage(float amount, DamageType type)
        {
            float damage = _baseDamageCalculationStrategy.CalculateDamage(amount, type, this);
            damage = Effect.CheckPreDamageEffect(damage);
            Current = Mathf.Clamp(Current - damage, 0, Max);
            Debug.Log($"-{damage} damage applied. CurrentHp : {Current}");
            CheckDeath();
        }

        public void SetDamageCalculationStrategy(BaseDamageCalculationStrategy calculationStrategy)
        {
            _baseDamageCalculationStrategy = calculationStrategy;
        }

        private void CheckDeath()
        {
            if (Current <= 0)
            {
                OnDeath?.Invoke();
            }            
        }

        public void Dispose()
        {
        }
    }
}