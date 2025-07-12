using Game.HealthSystem.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.HealthSystem
{
    [System.Serializable]
    public class HealthData
    {
        public int Health;
        public int MaxHealth;
        public Resistance Resistance;
        
        [SerializeReference][ShowInInspector] [PolymorphicDrawerSettings(ShowBaseType = false)] [InlineProperty]
        public BaseDamageCalculationStrategy DamageCalculationStrategy;
    }
}