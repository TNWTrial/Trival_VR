using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TNW
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField]
        GameObject BulletObject = null;



        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(BulletObject, transform.position + new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
            }
        }
    }
}