using UnityEngine;

namespace Game.HealthSystem
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