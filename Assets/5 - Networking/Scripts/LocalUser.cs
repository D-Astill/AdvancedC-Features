﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    [RequireComponent(typeof(Player))]
    public class LocalUser : MonoBehaviour
    {
        private Player player;

        void Start()
        {
            player = GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
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

