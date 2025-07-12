using Sirenix.OdinInspector;

namespace Game.HealthSystem
{
    public abstract class DebuffData : StatusEffectData
    {
        public abstract BaseDebuff GetInstance();
    }
    
    [TypeRegistryItem(Name = nameof(DecreaseHealingDebuffData))]
    public class DecreaseHealingDebuffData : DebuffData
    {
        public float Percentage;
        public float Duration;

        public override BaseDebuff GetInstance()
        {
            return new DecreaseHealingDebuff(Percentage, Duration);
        }
    }
}