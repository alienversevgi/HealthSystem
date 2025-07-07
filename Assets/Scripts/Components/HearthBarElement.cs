using System;
using UnityEngine;

namespace Game.HealthSystem
{
    public class HearthBarElement : MonoBehaviour
    {
        [SerializeField] private RectTransform target;

        private void Update()
        {
            Quaternion rotation = Quaternion.LookRotation(
                target.transform.position -  this.transform.position ,
                this.transform.TransformDirection(Vector3.up)
            );
            
            this.transform.rotation = new Quaternion( 0 , 0 , rotation.z , rotation.w );
        }
    }
}