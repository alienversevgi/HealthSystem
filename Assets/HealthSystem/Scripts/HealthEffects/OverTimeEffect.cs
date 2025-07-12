using System;
using Cysharp.Threading.Tasks;
using EventBus;
using UnityEngine.Events;

namespace Game.HealthSystem
{
    public abstract class OverTimeEffect : IHealthEffect
    {
        protected float Amount { get; private set; }
        protected int Duration { get; private set; }
        protected CountDownType Type { get; private set; }
        protected HealthController Health { get; private set; }

        public UnityEvent<HealthEffectEvent.OverTimeStarted> OverTimeStarted;
        public UnityEvent<HealthEffectEvent.OverTimeTick> OverTimeTick;
        public UnityEvent<HealthEffectEvent.OverTimeCompleted> OverTimeCompleted;

        public OverTimeEffect(float amount,
            int duration, CountDownType type)
        {
            Duration = duration;
            Amount = amount;
            Type = type;

            OverTimeStarted = new UnityEvent<HealthEffectEvent.OverTimeStarted>();
            OverTimeTick = new UnityEvent<HealthEffectEvent.OverTimeTick>();
            OverTimeCompleted = new UnityEvent<HealthEffectEvent.OverTimeCompleted>();
        }

        public virtual void Initialize(HealthController health)
        {
            Health = health;
        }

        public abstract OverTimeEffectType GetOverTimeType();

        public async UniTask Apply()
        {
            OverTimeStarted?.Invoke(new HealthEffectEvent.OverTimeStarted()
            {
                EffectType = GetOverTimeType(),
                Duration = Duration,
                CountDownType = Type
            });

            switch (Type)
            {
                case CountDownType.Increase:
                    for (int i = 0; i < Duration; i++)
                    {
                        if (await ExecuteAction(i))
                            break;
                    }

                    break;
                case CountDownType.Decrease:
                    for (int i = Duration; i > 0; i--)
                    {
                        if (await ExecuteAction(i))
                            break;
                    }

                    break;
            }

            Health.Effect.RemoveOverTimeEffect(this);

            OverTimeCompleted?.Invoke(new HealthEffectEvent.OverTimeCompleted()
            {
                EffectType = GetOverTimeType(),
            });

            return;

            async UniTask<bool> ExecuteAction(int i)
            {
                if (CheckBreakCondition())
                    return true;

                int target = Type == CountDownType.Increase ? i + 1 : i - 1;

                OverTimeTick?.Invoke(new HealthEffectEvent.OverTimeTick
                {
                    EffectType = GetOverTimeType(),
                    Current = target
                });

                ExecutePerAction();

                await UniTask.Delay(TimeSpan.FromSeconds(1));

                return false;
            }
        }

        protected abstract void ExecutePerAction();

        protected abstract bool CheckBreakCondition();

        public void Reset()
        {
            OverTimeStarted.RemoveAllListeners();
            OverTimeTick.RemoveAllListeners();
            OverTimeCompleted.RemoveAllListeners();
        }
    }
}