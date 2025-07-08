using Game.HealthSystem.Interfaces;

namespace Game.HealthSystem
{
    public class DefaultDamageCalculationStrategy : IDamageCalculationStrategy
    {
        public float CalculateDamage(float amount, DamageType type, HealthController health)
        {
            var reduction =  health.GetResistance().DamageReductions[type];
            
            return amount * (1 - reduction);
        }
    }
}