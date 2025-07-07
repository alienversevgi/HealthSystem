using System;
using System.ComponentModel;
using Sirenix.OdinInspector;
using SRDebugger;
using UnityEngine;

namespace Game.HealthSystem
{
    public class TestDamageDealer : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private HealthController target => player.Health;

        [Button]
        public void TestDefaultDamage(float amount, DamageType damageType)
        {
            DefaultDamageCalculationStrategy calculationStrategy = new DefaultDamageCalculationStrategy();
            target.ApplyDamage(amount, damageType, calculationStrategy);
        }

        [Button]
        public void TestHeal(float amount)
        {
            target.ApplyHeal(amount);
        }
        
        [Button]
        public void TestDoT(float amount, int duration,DamageType damageType, CountDownType type)
        {
            DoTEffect doTEffect = new DoTEffect(amount, damageType, duration, type);
            target.Effect.AddOverTimeEffect(doTEffect);
        }

        [Button]
        public void TestLoT(float amount, int duration, CountDownType type)
        {
            LoTEffect effect = new LoTEffect(amount, duration, type);
            target.Effect.AddOverTimeEffect(effect);
        }

        [Button]
        public void TestDecreaseDamageBuff(float percentage, float duration)
        {
            DecreaseDamageBuff buff = new DecreaseDamageBuff(percentage, duration);
            target.Effect.AddBuff(buff);
        }

        [Button]
        public void TestDecreaseHealingDebuff(float percentage, float duration)
        {
            DecreaseHealingDebuff buff = new DecreaseHealingDebuff(percentage, duration);
            target.Effect.AddDebuff(buff);
        }
    }
}