using Game.HealthSystem;
using UnityEngine;

namespace Game.Example
{
    public static class AttackUtil
    {
        public static void ApplyAttack(TestAttackData data, HealthController target)
        {
            if (data.DamageData.Amount > 0)
            {
                Debug.Log("Applying damage");
                target.ApplyDamage(data.DamageData.Amount, data.DamageData.DamageType);
            }

            if (data.BuffData != null)
            {
                Debug.Log("Applying buff");
                target.Effect.AddBuff(data.BuffData.GetInstance());
            }
            
            if (data.DebuffData != null)
            {
                Debug.Log("Applying debuff");
                target.Effect.AddDebuff(data.DebuffData.GetInstance());
            }

            if (data.OverTimeEffectData != null)
            {
                Debug.Log("Applying overtime");
                target.Effect.AddOverTimeEffect(data.OverTimeEffectData.GetInstance());
            }
        }
    }
}