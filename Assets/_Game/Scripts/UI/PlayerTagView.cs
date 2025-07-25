using System;
using EventBus;
using UnityEngine;

namespace Game.Example
{
    public class PlayerTagView : MonoBehaviour, IDisposable
    {
        [SerializeField] private PlayerController controller;
        [SerializeField] private CircularProgressBar progressBar;
        [SerializeField] private TimerView timerView;

        public void Initialize()
        {
            progressBar.Initialize();
            progressBar.SetRange(0, controller.Health.Max);
            timerView.Initialize();

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            controller.Health.OnHealthChanged += OnHealthChanged;
            controller.Health.Effect.OnOverTimeAdded.AddListener(OnOverTimeEffectAdded);
        }

        private void OnOverTimeEffectAdded(HealthEffectEvent.OverTimeAdded eventData)
        {
            controller.Health.Effect.GetOverTimeEffect(eventData.EffectType).OverTimeStarted
                .AddListener(OnOverTimeEffectStarted);
            controller.Health.Effect.GetOverTimeEffect(eventData.EffectType).OverTimeTick
                .AddListener(OnOverTimeEffectTick);
            controller.Health.Effect.GetOverTimeEffect(eventData.EffectType).OverTimeCompleted
                .AddListener(OnOverTimeEffectCompleted);
        }

   

        private void DeregisterEvents()
        {
            controller.Health.OnHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float health)
        {
            progressBar.SetProgressValue(health);
        }

        private void OnOverTimeEffectStarted(HealthEffectEvent.OverTimeStarted eventData)
        {
            timerView.Setup(eventData.Duration, eventData.CountDownType);
        }

        private void OnOverTimeEffectTick(HealthEffectEvent.OverTimeTick eventData)
        {
            timerView.UpdateValue(eventData.Current);
        }

        private void OnOverTimeEffectCompleted(HealthEffectEvent.OverTimeCompleted eventData)
        {
            timerView.Complete().Forget();
        }

        public void Dispose()
        {
            DeregisterEvents();
        }
    }
}