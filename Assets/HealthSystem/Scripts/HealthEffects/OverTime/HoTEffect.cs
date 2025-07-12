namespace Game.HealthSystem
{
    public class HoTEffect : OverTimeEffect
    {
        public HoTEffect(float amount, int duration, CountDownType type) : base(amount, duration, type)
        {
        }

        public override OverTimeEffectType GetOverTimeType() => OverTimeEffectType.HoT;

        protected override void ExecutePerAction()
        {
            Health.ApplyHeal(Amount);
        }

        protected override bool CheckBreakCondition()
        {
            return Health.IsFulled;
        }
    }
}