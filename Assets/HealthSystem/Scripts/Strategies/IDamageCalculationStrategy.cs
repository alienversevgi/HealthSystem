namespace Game.HealthSystem.Interfaces
{
    public interface IDamageCalculationStrategy
    {
        float CalculateDamage(float amount, DamageType type, HealthController health);
    }
}