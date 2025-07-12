using Sirenix.OdinInspector;

namespace Game.HealthSystem
{
    public abstract class OverTimeEffectData
    {
        public CountDownType CountDownType;
        public int Duration;
        public float Amount;

        public abstract OverTimeEffect GetInstance();
    }

    [TypeRegistryItem(Name = nameof(HoTEffectData))]
    public class HoTEffectData : OverTimeEffectData
    {
        public override OverTimeEffect GetInstance()
        {
            return new HoTEffect(Amount, Duration, CountDownType);
        }
    }

    [TypeRegistryItem(Name = nameof(DoTEffectData))]
    public class DoTEffectData : OverTimeEffectData
    {
        public DamageType DamageType;

        public override OverTimeEffect GetInstance()
        {
            return new DoTEffect(Amount, DamageType, Duration, CountDownType);
        }
    }
}