using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        public float acceleration = 25f;
        public float hyperSpeed = 150f;
        public float deceleration = 0.1f;
        public float rotationSpeed = 5f;

        private Rigidbody2D rb;


        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody2D>(); 
        }
        void Update()
        {
            float inputV = Input.GetAxisRaw("Vertical");
            float inputH = Input.GetAxis("Horizontal");
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Accelerate();
            Decelerate();
            Rotate();
        }

        void Accelerate()
        {
            float inputV = Input.GetAxis("Vertical");
            
            Vector2 force = transform.right * inputV;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                force *= hyperSpeed;
            }
            else
            {
                force *= acceleration;
            }
            

        }
        void Decelerate()
        {
            //velocity += -velocity * decekeration
            rb.velocity += -rb.velocity * deceleration;
        }
        void Rotate()
        {
            float inputH = Input.GetAxis("Horizontal");
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * inputH, Vector3.back);
        }
    }

}
