using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TNW
{
    public class BulletBehaviour : MonoBehaviour
    {

        private float speed = 10.0f;

        private float lifetime = 3.0f;

        // Use this for initialization
        void Start()
        {
            Invoke("DestroyObject", lifetime);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        void DestroyObject()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Destructable")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}