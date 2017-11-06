using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarFoxClone
{

    public class XWingController : MonoBehaviour
    {
        public enum Mode
        {
            CONFINED = 0,
            ALL_RANGE = 1
        }

        public Mode xwingMode = Mode.CONFINED;

        [Header("Camera")]
        public float cameraYSpeed = 10f;
        public float cameraMoveSpeed = 90f;
        public float cameraDistance = 20f;

        [Header("Xwing")]
        public Transform aimTarget;
        public Transform moveTarget;
        public float aimingSpeed = 15f;
        public float movementSpeed = 40f;
        public float rotationSpeed = 10f;

        private Camera parentCam;
        private float startDistance = 5f;
        private Vector3 up = Vector3.up;


        // Use this for initialization
        void Start()
        {
            parentCam = GetComponentInParent<Camera>();
            startDistance = Vector3.Distance(parentCam.transform.position, transform.position);

        }

        void MoveXToY(Transform x, Transform y, float speed)
        {
            Vector3 xPos = x.position;
            Vector3 yPos = y.position;

            // Move the Xwing towards aimTarget
            xPos = Vector3.MoveTowards(xPos, yPos, speed * Time.deltaTime);

            x.position = xPos;
        }

        void MoveXWingToMoveTarget()
        {
            // Get global aim target pos
            MoveXToY(transform, moveTarget, movementSpeed);

            // Reset z locally to startDistance
            Vector3 localArwingPos = transform.localPosition;
            localArwingPos.z = startDistance;
            transform.localPosition = localArwingPos;

        }

        void MoveTargetToXWing()
        {
            //Get the aim target and Xwing local position 
            Vector3 localAimTargetPos = aimTarget.localPosition;
            Vector3 localXwingPos = transform.localPosition;

            localAimTargetPos = Vector3.MoveTowards(localAimTargetPos,
              localXwingPos, movementSpeed * Time.deltaTime);

            // Apply aim target's local position
            aimTarget.localPosition = localAimTargetPos;
            transform.localPosition = localXwingPos;
        }

        void RotateXWingToAimTarget()
        {
            // Get direction to AimTarget from Xwing
            Vector3 direction = aimTarget.position - transform.position;

            // Get rotation to up
            Quaternion rotation = Quaternion.LookRotation(direction, up);

            // Lerp rotation for Xwing
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, aimingSpeed * Time.deltaTime);
        }

        // Moves forward with camera
        void MoveForward()
        {
            parentCam.transform.position +=
                parentCam.transform.forward *
                cameraMoveSpeed * Time.deltaTime;
        }

        // Gets the camera to follow arwing (only in All_Range mode)
        void FollowXwing()
        {
            // Get camera's position & rotation
            Vector3 position = parentCam.transform.position;
            Quaternion rotation = parentCam.transform.rotation;
            // Get local position of target and arwing
            Vector3 localXwingPos = transform.position;
            Vector3 localTargetPos = moveTarget.localPosition;
            // Calculate direction with localPos
            Vector3 direction = localTargetPos - localXwingPos;
            // Rotate the camera to direction
            rotation *= Quaternion.AngleAxis(direction.x * rotationSpeed * Time.deltaTime, Vector3.up);
            // Move the camera up at different speed
            position.y += direction.y * cameraYSpeed * Time.deltaTime;
            // Apply newly made position to camera
            parentCam.transform.position = position;
            parentCam.transform.rotation = rotation;
        }

        void MoveTarget(float inputH, float inputV)
        {
            // Get inputDir 
            Vector3 inputDir = new Vector3(inputH, inputV, 0);
            // Calculate force by inputDir x movementSpeed
            Vector3 force = inputDir * movementSpeed;
            // Offset aimTarget by force
            moveTarget.localPosition += force * Time.deltaTime;
        }

        public void Move(float inputH, float inputV)
        {
            // Move to target
            MoveTarget(inputH, inputV);
            // Move forward
            MoveForward();
            // Move based on arwing mode
            switch (xwingMode)
            {
                case Mode.CONFINED:
                    break;
                case Mode.ALL_RANGE:
                    FollowXwing();
                    break;
                default:
                    break;
            }

            // If no input is made
            if (inputH == 0 && inputV == 0)
            {
                MoveTargetToXWing();
            }
            // Move target to arwing

            // Move the arwing to move target
            MoveXWingToMoveTarget();
            //Rotate Xwing to aim target
            RotateXWingToAimTarget();

        }
    }

}