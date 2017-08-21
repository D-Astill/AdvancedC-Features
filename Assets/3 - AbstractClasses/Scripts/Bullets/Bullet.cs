using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Bullet : MonoBehaviour
    {
        public float speed = 10f;
        public float aliveDistance = 5f;

        private Rigidbody2D rb;
        private Vector3 shotPos;
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            shotPos = transform.position;
        }


        public void Fire(Vector3 direction, float? speed = null)
        {
            float currentSpeed = this.speed;
            //check if speed has been used
            if (speed != null)
            {
                currentSpeed = speed.Value;
            }
            //Fire off in the direction with current speed
            rb.AddForce(direction * currentSpeed, ForceMode2D.Impulse);
        }
    }
}
