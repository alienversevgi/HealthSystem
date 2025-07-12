namespace Game.HealthSystem.Interfaces
{
    [System.Serializable]
    public abstract class BaseDamageCalculationStrategy
    {
        public abstract float CalculateDamage(float amount, DamageType type, HealthController health);
    }
}