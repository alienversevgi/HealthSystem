using System;
using Game.Example;
using UnityEngine;

namespace _Game.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerTagView playerTag;
        [SerializeField] private PlayerController playerController;

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            playerController.Initialize();
            playerTag.Initialize();
        }
    }
}