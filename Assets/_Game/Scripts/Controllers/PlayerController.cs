using Game.HealthSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Example
{
    public class PlayerController : SerializedMonoBehaviour
    {
        [SerializeField] private HealthData healthData;
        public HealthController Health { get; private set; }

        public void Initialize()
        {
            Health = new HealthController();
            Health.Initialize(healthData);
        } 
    }
}