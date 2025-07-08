using Game.HealthSystem;

namespace EventBus
{
    public static class HealthEffectEvent
    {
        public struct OverTimeAdded
        {
            public OverTimeEffectType EffectType { get; set; }
        }
        
        public struct OverTimeRemoved
        {
            public OverTimeEffectType EffectType { get; set; }
        }
        
        public struct OverTimeStarted 
        {
            public OverTimeEffectType EffectType { get; set; }
            public CountDownType CountDownType { get; set; }
            public float Duration { get; set; }
        }

        public struct OverTimeTick 
        {
            public OverTimeEffectType EffectType { get; set; }
            public float Current { get; set; }
        }

        public struct OverTimeCompleted
        {
            public OverTimeEffectType EffectType { get; set; }
        }
    }
}