using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarFoxClone
{
    public class UserControll : MonoBehaviour
    {

        public XWingController XWingController;

        // Update is called once per frame
        void Update()
        {
            // Get inputH and inputV
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            XWingController.Move(inputH, inputV);
        }
    }
}