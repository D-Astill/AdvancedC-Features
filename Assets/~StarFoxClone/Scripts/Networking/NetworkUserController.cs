using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace StarFoxClone
{
    public class NetworkUserController : NetworkBehaviour
    {
        public XWingController XwingController;
        private Camera cam;
        private AudioListener audioListener;

        // Use this for initialization
        void Start()
        {
            cam = GetComponent<Camera>();
            audioListener = GetComponent<AudioListener>();
            if (!isLocalPlayer)
            {
                cam.enabled = false;
                audioListener.enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer)
            {
                float inputH = Input.GetAxis("Horizontal");
                float inputV = Input.GetAxis("Vertical");
            }
        }
    }
}