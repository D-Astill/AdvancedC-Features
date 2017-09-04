using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitWithZoom : MonoBehaviour {
    public Transform target; // Center of minefields
    public float distance = 5.0f;
    public float sensitivity = 1f;

    public float distanceMin = 0.5f;
    public float distanceMax = 15;

    float x = 0.0f;
    float y = 0.0f;
	// Use this for initialization
	void Start ()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
	}

    void HideCursor(bool isHiding)
    {
        if (isHiding)
        {
            Cursor.visible = false;
            //hide the cursor
        }
        else
        {
            Cursor.visible = true;
            //show cursor
        }
    }

    void GetInput()
    {
        x += Input.GetAxis("Mouse X") * sensitivity;
        y -= Input.GetAxis("Mouse Y") * sensitivity;

        float inputScroll = Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance - inputScroll, distanceMin, distanceMax);
    }

    void Movement()
    {
        if (target)
        {
            Quaternion rotation = Quaternion.Euler(y, x, 0);

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
	
	void LateUpdate ()
    {
            
        if (Input.GetKey(KeyCode.Mouse1))
        {
            HideCursor(true);
            GetInput();
        }
        else
        {
            HideCursor(false);
        }
        Movement();
	}
}
