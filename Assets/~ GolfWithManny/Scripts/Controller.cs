﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

namespace GolfWithManny
{
    [RequireComponent(typeof(Player))]
    public class Controller : NetworkBehaviour
    {
        private Player p;
        public Camera cam;
        // Use this for initialization
        void Awake()
        {
            p = GetComponent<Player>();
        }
        void Start()
        {
            if (!isLocalPlayer)
            {
                cam.gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Vector3 forward = cam.transform.forward;
                    p.Move(forward);
                }
            }
        }
    }

}
