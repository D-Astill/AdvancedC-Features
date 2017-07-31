using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delagates
{
    public class PlayerMovement : MonoBehaviour
    {
        public float acceleration = 200f;
        public float deceleration = .01f;

        private Rigidbody rb;
        // Use this for initialization
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        // Update is called once per frame
        void Update()
        {
            Accelerate();
            Decelerate();
        }
        void Accelerate()
        {
            //Gathers input data
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            //Calculater input direction
            Vector3 inputDir = new Vector3(inputH, 0, inputV);
            rb.AddForce(inputDir * acceleration);
        }

        void Decelerate()
        {
            //Velocity = -velocity x deceleration
            rb.velocity = -rb.velocity * deceleration;
        }


    }

}
