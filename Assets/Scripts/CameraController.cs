using UnityEngine;

namespace TNW
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        Transform target;

        /// <summary>
        /// 仰角
        /// </summary>
        private float elevation = 0.0f;

        /// <summary>
        /// 方位角
        /// </summary>
        private float azimuth = 90.0f;

        /// <summary>
        /// カメラとの距離
        /// </summary>
        private float distance = 3.0f;

        /// <summary>
        /// 前のフレームのマウスの座標
        /// </summary>
        private Vector3 oldMousePosition;

        /// <summary>
        /// カメラの回転スピード
        /// </summary>
        private float rotateSpeed = 0.2f;

        /// <summary>
        /// カメラの相対座標
        /// </summary>
        private Vector3 cameraPosition;

        // Use this for initialization
        void Start()
        {
            oldMousePosition = Input.mousePosition;
            UpdateCameraPosition();
            UpdateCameraRotation();
        }
        
        private void LateUpdate()
        {
            UpdateCamera();
            UpdateCameraRotation();
        }


        void UpdateCamera()
        {
            Vector3 newMousePos = Input.mousePosition;

            if (Input.GetMouseButton(1))
            {
                float lenX = newMousePos.x - oldMousePosition.x;
                float lenY = newMousePos.y - oldMousePosition.y;

                elevation += (Mathf.Abs(lenX) > Mathf.Abs(lenY)) ? 0.0f : lenY * rotateSpeed;
                elevation = RoundDeg(elevation);

                azimuth += (Mathf.Abs(lenX) > Mathf.Abs(lenY)) ? lenX * -rotateSpeed : 0.0f;
                azimuth = RoundDeg(azimuth);

                UpdateCameraPosition();
            }

            oldMousePosition = newMousePos;

            transform.position = target.position - cameraPosition;
        }

        void UpdateCameraPosition()
        {
            float cameraY = distance * Mathf.Sin(elevation * Mathf.Deg2Rad);

            float hypotenuseXZ = distance * Mathf.Cos(elevation * Mathf.Deg2Rad);

            float cameraZ = hypotenuseXZ * Mathf.Sin(azimuth * Mathf.Deg2Rad);
            float cameraX = hypotenuseXZ * Mathf.Cos(azimuth * Mathf.Deg2Rad);

            cameraPosition = new Vector3(cameraX, cameraY, cameraZ);
        }

        void UpdateCameraRotation()
        {
            transform.LookAt(target);
        }

        float RoundDeg(float angle)
        {
            float result = angle;
            if (result > 360.0f) { result -= 360.0f; }
            if (result < 0.0f ) { result += 360.0f; }

            return result;
        }
    }
}