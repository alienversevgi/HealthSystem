namespace Game.HealthSystem
{
    public class DoTEffect : OverTimeEffect
    {
        private DefaultDamageCalculationStrategy _damageCalculationStrategy;
        private DamageType _damageType;

        public DoTEffect(float amount, DamageType damageType, int duration, CountDownType type) 
            : base(amount, duration,
            type)
        {
            _damageType = damageType;
        }

        public override OverTimeEffectType GetOverTimeType() => OverTimeEffectType.DoT;

        public override void Initialize(HealthController health)
        {
            base.Initialize(health);
            _damageCalculationStrategy = new DefaultDamageCalculationStrategy();
        }

        protected override void ExecutePerAction()
        {
            Health.ApplyDamage(Amount, _damageType, _damageCalculationStrategy);
        }

        protected override bool CheckBreakCondition()
        {
            return Health.IsDead;
        }
    }
}