namespace Game.HealthSystem
{
    public class DoTEffect : OverTimeEffect
    {
        private DamageType _damageType;

        public DoTEffect(float amount, DamageType damageType, int duration, CountDownType type) 
            : base(amount, duration,
            type)
        {
            _damageType = damageType;
        }

        public override OverTimeEffectType GetOverTimeType() => OverTimeEffectType.DoT;


        protected override void ExecutePerAction()
        {
            Health.ApplyDamage(Amount, _damageType);
        }

        protected override bool CheckBreakCondition()
        {
            return Health.IsDead;
        }
    }
}