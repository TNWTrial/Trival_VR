using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TNW.VR
{
    public class FirstPersonControllerVR : MonoBehaviour
    {

        [SerializeField]
        Transform vrCamera = null;

        [SerializeField]
        private float speed = 5.0f;

        private CharacterController characterController;

        private Shoot shoot;

        private Animator animator;

        private Vector3 offset;

        private void Start()
        {
            characterController = GetComponent<CharacterController>();

            shoot = GetComponent<Shoot>();

            animator = GetComponent<Animator>();

            offset = transform.position - vrCamera.position;
        }

        private void Update()
        {
            Vector3 forward = vrCamera.forward;
            forward.y = 0;
            forward = forward.normalized;
            
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = vertical * forward;

            characterController.Move(direction * speed * Time.deltaTime);

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);

                vrCamera.position = transform.position - offset;
            }

            animator.SetFloat("Speed", direction.magnitude);

            if (Input.GetMouseButtonDown(0))
            {
                shoot.Shooting();
                animator.Play("robot_shot");
            }
        }
    }
}
