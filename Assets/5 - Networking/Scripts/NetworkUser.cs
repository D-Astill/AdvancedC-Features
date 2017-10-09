using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Networking
{
    [RequireComponent(typeof(Player))]
    public class NetworkUser : NetworkBehaviour
    {
        public Camera cam;
        public AudioListener audLis;
        private Player player;

        void Start()
        {
            player = GetComponent<Player>();
            if (!isLocalPlayer)
            {
                cam.enabled = false;
                audLis.enabled = false;
            }            
        }

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer)
            {
                float h = Input.GetAxis("Mouse X");
                h += Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                player.Move(h, v);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.Jump();
                }
            }
        }
    }

}

