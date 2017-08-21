using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class RotateToVelocity2D : MonoBehaviour {
    private Rigidbody2D rb;
	// Use this for initialization
	void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 vel = rb.velocity;
        //Mathf.Atan2 Takes in two floats
        float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
