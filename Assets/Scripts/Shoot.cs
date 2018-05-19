using UnityEngine;

namespace TNW
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField]
        GameObject BulletObject = null;
        
        public void Shooting()
        {
#if STUDENT

            // 弾を生成する

#else
            Instantiate(BulletObject, transform.position + new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
#endif
        }
    }
}