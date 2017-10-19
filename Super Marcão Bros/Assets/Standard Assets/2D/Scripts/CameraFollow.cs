using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        private void Start()
        {
            
        }
        private void Update()
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
    }
}
