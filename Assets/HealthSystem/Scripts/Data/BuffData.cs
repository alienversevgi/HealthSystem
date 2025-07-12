using System;
using Sirenix.OdinInspector;

namespace Game.HealthSystem
{
    public abstract class BuffData : StatusEffectData
    {
        public abstract BaseBuff GetInstance();
    }

    [TypeRegistryItem(Name = nameof(DecreaseDamageBuffData))]
    public class DecreaseDamageBuffData : BuffData
    {
        public float Percentage;
        public float Duration;
        
        public override BaseBuff GetInstance()
        {
            return new DecreaseDamageBuff(Percentage, Duration);
        }
    }
}