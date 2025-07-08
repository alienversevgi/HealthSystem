using Game.HealthSystem;
using UnityEngine;

namespace Game.Example
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private HealthData healthData;
        public HealthController Health { get; private set; }
        
        private void Awake()
        {
            StartGame();
        }

        public void StartGame()
        {
            Health = new HealthController();
            Health.Initialize(healthData);
        } 
    }
}