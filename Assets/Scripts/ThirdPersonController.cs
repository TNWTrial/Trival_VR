using UnityEngine;

namespace TNW
{ 
    [RequireComponent(typeof(CharacterController))]
    public class ThirdPersonController : MonoBehaviour
    {
        [SerializeField]
        private Camera viewCamera;

        [SerializeField]
        private float speed = 5.0f;

        private CharacterController characterController;

#if STUDENT

        // Shootスクリプトの定義
        

        // アニメーターの定義

#else
        private Shoot shoot;
        private Animator animator;
#endif

	    // Use this for initialization
	    void Start ()
        {
            characterController = GetComponent<CharacterController>();

#if STUDENT

            // Shootスクリプトの初期化
            
            // アニメーターの初期化

#else
            shoot = GetComponent<Shoot>();
            animator = GetComponent<Animator>();
#endif
        }

        // Update is called once per frame
        void Update ()
        {
            Vector3 forward = viewCamera.transform.forward;
            forward.y = 0;
            forward = forward.normalized;

            Vector3 right = new Vector3(forward.z, 0.0f, -forward.x);

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = horizontal * right + vertical * forward;

#if STUDENT

            // 移動処理


            // 弾を発射する処理


#else
            characterController.Move(direction * speed * Time.deltaTime);

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            animator.SetFloat("Speed", direction.magnitude);

            if (Input.GetMouseButtonDown(0))
            {
                shoot.Shooting();
                animator.Play("robot_shot");
            }

#endif

        }
    }
}