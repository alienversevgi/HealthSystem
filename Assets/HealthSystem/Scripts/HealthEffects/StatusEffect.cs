using Cysharp.Threading.Tasks;
using Game.HealthSystem.Interfaces;

namespace Game.HealthSystem
{
    public abstract class StatusEffect : IHealthEffect
    {
        protected HealthController Health { get; private set; }

        public virtual void Initialize(HealthController health)
        {
            Health = health;
        }

        public abstract UniTask Apply();

        public virtual void Reset()
        {
        }

        public virtual float CheckPreDamageEffect(float damage)
        {
            return damage;
        }

        public virtual float CheckPreHealingEffect(float healing)
        {
            return healing;
        }
    }
}