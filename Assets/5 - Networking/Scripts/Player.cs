using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 8f;
        public float rotationSpeed = 360f;
        public float jumpHeight = 2.0f;

        private bool isGrounded = false;
        [HideInInspector]
        public Rigidbody rb;
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void Move(float h, float v)
        {
            Vector3 pos = rb.position;
            Quaternion rot = rb.rotation;

            pos += transform.forward * v * movementSpeed * Time.deltaTime;
            rot *= Quaternion.AngleAxis(rotationSpeed * h * Time.deltaTime, Vector3.up);

            rb.MovePosition(pos);
            rb.MoveRotation(rot);

        }

        public void Jump()
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
            }
        }

        void OnCollisionEnter(Collision other)
        {
            isGrounded = true;
        }
    }

}

