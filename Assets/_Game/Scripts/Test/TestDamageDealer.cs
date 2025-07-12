using Game.HealthSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Example
{
    public class TestDamageDealer : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField,InlineEditor] private TestAttackData attackData;
        
        private HealthController target => player.Health;

        [Button]
        public void TestDefaultDamage(float amount, DamageType damageType)
        {
            target.ApplyDamage(amount, damageType);
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
            HoTEffect effect = new HoTEffect(amount, duration, type);
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

        [Button]
        public void Attack()
        {
            AttackUtil.ApplyAttack(attackData, target);
        }
    }
}