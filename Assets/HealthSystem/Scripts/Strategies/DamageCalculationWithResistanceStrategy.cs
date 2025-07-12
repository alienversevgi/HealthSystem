using Game.HealthSystem.Interfaces;

namespace Game.HealthSystem
{
    [System.Serializable]
    public class DamageCalculationWithResistanceStrategy : BaseDamageCalculationStrategy
    {
        public override float CalculateDamage(float amount, DamageType type, HealthController health)
        {
            var reduction =  health.GetResistance().DamageReductions[type];
            
            return amount * (1 - reduction);
        }
    }
}