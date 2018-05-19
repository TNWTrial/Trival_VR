using UnityEngine;

namespace TNW
{
    public class VRCamera : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            if (SystemInfo.supportsGyroscope)
            {
                Input.gyro.enabled = true;
            }
            else
            {
                Debug.Log("Phone doesen't support");
            }
        }

        private void Update()
        {
            var rotRH = Input.gyro.attitude;
            var rot = new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w) * Quaternion.Euler(90f, 0f, 0f);

            transform.localRotation = rot;
        }
        
    }
}