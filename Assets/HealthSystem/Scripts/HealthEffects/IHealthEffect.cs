using Cysharp.Threading.Tasks;

namespace Game.HealthSystem
{
    public interface IHealthEffect
    {
        void Initialize(HealthController health);
        UniTask Apply();
        void Reset();
    }
}