using Game.HealthSystem.Interfaces;

namespace Game.HealthSystem
{
    [System.Serializable]
    public class DefaultDamageCalculationStrategy : BaseDamageCalculationStrategy
    {
        public override float CalculateDamage(float amount, DamageType type, HealthController health)
        {
            return amount;
        }
    }
}