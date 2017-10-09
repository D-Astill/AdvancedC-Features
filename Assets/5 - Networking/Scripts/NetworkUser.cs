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
        [SyncVar] Vector3 synePos;
        [SyncVar] Quaternion syncRot;
        [Range(0,1)]
        public float lerpRate = 1f;
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
                Rigidbody rigid = player.rb;
                Cmd_SendPositionToServer(rigid.position);
                Cmd_SendRotationToServer(rigid.rotation);
            }
            else
            {
                LerpPos();
                LerpRot();
            }
        }

        void LerpPos()
        {
            Rigidbody rb = player.rb;
            rb.position = Vector3.Lerp(rb.position, synePos, lerpRate);
        }
        void LerpRot()
        {
            Rigidbody rb = player.rb;
            rb.rotation = Quaternion.Lerp(rb.rotation, syncRot, lerpRate);
        }
        [Command]
        void Cmd_SendPositionToServer(Vector3 pos)
        {
            synePos = pos;
        }
        [Command]
        void Cmd_SendRotationToServer(Quaternion rot)
        {
            syncRot = rot;
        }
    }

}

