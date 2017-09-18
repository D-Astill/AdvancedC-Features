using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GolfWithManny
{

    public class Player : MonoBehaviour
    {

        public float speed = 50f;
        public float maxVelocity = 20f;

        private Rigidbody rb;

        // Use this for initialization
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 vel = rb.velocity;
            if (vel.magnitude > maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }
            rb.velocity = vel;
        }
        public void Move(Vector3 direction)
        {
            rb.AddForce(direction * speed, ForceMode.Impulse);
        }
    }

}
