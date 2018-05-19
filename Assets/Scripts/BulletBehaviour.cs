using UnityEngine;

namespace TNW
{
    public class BulletBehaviour : MonoBehaviour
    {

        [SerializeField]
        private AudioClip create;

        [SerializeField]
        private AudioClip destory;

        [SerializeField]
        private GameObject effectObject;

        private float speed = 20.0f;

        private float lifetime = 1.0f;

        // Use this for initialization
        void Start()
        {
            Invoke("DestroyObject", lifetime);
            SoundManger.Instance.PlaySe(create.name);
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
#if STUDENT

            // 当たったら弾と対照オブジェクトを消す

#else
                Destroy(other.gameObject);
                Destroy(gameObject);
                CreateEffect();
#endif
            }
        }

        private void OnDestroy()
        {
            SoundManger.Instance.PlaySe(destory.name);
        }

        private void CreateEffect()
        {
            GameObject effect = Instantiate(effectObject, transform.position, Quaternion.identity);
            ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();
            Destroy(effect, particleSystem.duration);
        }
    }
}