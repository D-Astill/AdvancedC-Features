using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitWithZoom : MonoBehaviour {
    public Transform target;
    public float distance = 5f;
    public float sensitivity = 1f;
    public float distanceMin = .5f;
    public float distanceMax = 15f;

    [Header("Camera Collision")]
    public LayerMask ignoreLayers;
    public bool isEnabled = true;
    public float colRadius = 5f;

    float x = 0f;
    float y = 0f;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, colRadius);
    }

    // Use this for initialization
    void Start()
    {
        // Get the current axis of rotation on X and Y
        Vector3 angles = transform.eulerAngles;
        // Swap over X and Y because of axis
        x = angles.y;
        y = angles.x;
    }

    void HideCursor(bool isHiding)
    {
        if (isHiding)
        {
            // Hide the cursor
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
        else
        {
            // Unhide the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void GetInput()
    {
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * sensitivity;
            y -= Input.GetAxis("Mouse Y") * sensitivity;
        }

        float inputScroll = Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance - inputScroll, distanceMin, distanceMax);
    }

    void Movement()
    {
        if (target)
        {
            Quaternion rotation = Quaternion.Euler(y, x, 0);

            // Perform Raycast to hit the wall
            float dist = GetCollisionDistance();

            Vector3 negDistance = new Vector3(0, 0, -dist);
            Vector3 position = rotation * negDistance + target.position;

            transform.position = position;
            transform.rotation = rotation;
        }
    }

    float GetCollisionDistance()
    {
        float desiredDist = distance;

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 back = rotation * new Vector3(0, 0, -distance);

        Ray targetRay = new Ray(target.position, back);
        RaycastHit hit;
        if (Physics.SphereCast(targetRay, colRadius, out hit, desiredDist, ~ignoreLayers))
        {
            Vector3 point = hit.point + hit.normal * colRadius;
            desiredDist = Vector3.Distance(target.position, point);
        }

        return desiredDist;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            HideCursor(true);
        }
        else
        {
            HideCursor(false);
        }

        GetInput();
        Movement();
    }
}
