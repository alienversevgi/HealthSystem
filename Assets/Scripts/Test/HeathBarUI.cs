using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Test
{
    public class HeathBarUI : MonoBehaviour
    {
        [SerializeField] private RectTransform target;
        [SerializeField] private Transform hearthContainer;
        
        private List<RectTransform> _hearths;

        private void Awake()
        {
            _hearths = hearthContainer.GetComponentsInChildren<RectTransform>().ToList();
            _hearths.RemoveAt(0);
        }

    
    }
}