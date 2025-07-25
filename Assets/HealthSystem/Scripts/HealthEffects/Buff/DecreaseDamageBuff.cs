using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.HealthSystem
{
    public class DecreaseDamageBuff : BaseBuff
    {
        private readonly float _decreasePercentage;
        private readonly float _duration;

        public DecreaseDamageBuff(float decreasePercentage, float duration)
        {
            _decreasePercentage = decreasePercentage;
            _duration = duration;
        }

        public override async UniTask Apply()
        {
            Debug.Log($"{nameof(DecreaseDamageBuff)} is starting");
            await UniTask.Delay(TimeSpan.FromSeconds(_duration));
            Health.Effect.RemoveBuff(this);
        }

        public override float CheckPreDamageEffect(float damage)
        {
            return base.CheckPreDamageEffect(damage) * _decreasePercentage;
        }

        public override void Reset()
        {
            base.Reset();
            Debug.Log($"{nameof(DecreaseDamageBuff)} is finished!");
        }
    }
}