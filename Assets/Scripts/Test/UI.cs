using Game.HealthSystem;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI health;
        [SerializeField] private HealthController healthController;

        private void Start()
        {
            healthController.OnHealthChanged += (value) =>
            {
                health.text = $"Health: {value} / {healthController.GetMax()}";
            };
        }
    }
}