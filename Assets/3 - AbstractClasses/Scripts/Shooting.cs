using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Shooting : MonoBehaviour
    {
        public int weaponIndex = 0;
        private Weapon[] attachedWeapon;
        private Rigidbody2D rb;
        // Use this for initialization
        void Awake()
        {
            attachedWeapon = GetComponentsInChildren<Weapon>();
            rb = GetComponent<Rigidbody2D>();
        }
        void Start()
        {
            SwitchWeapon(weaponIndex);
        }
        void CycleWeapon(int amount)
        {
            //Set desired index to weaponindex + amount
            int desiredIndex = weaponIndex + amount;
            //if desiredindex > weapon length
            if (desiredIndex >= attachedWeapon.Length)
            {
                desiredIndex = 0;
            }
            else if (desiredIndex < 0)
            {
                desiredIndex = attachedWeapon.Length - 1;
            }
            weaponIndex = desiredIndex;
            SwitchWeapon(weaponIndex);
                //Set desiredIndex to zero
            //else if(desiredIndex < zero)
                //Set DesiredIndex = weaponlength -1;
            //Set weaponIndex to desiredIndex
            //SwitchWeapon() and pass weaponIndex
        }
        void Update()
        {
            CheckFire();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CycleWeapon(-1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                CycleWeapon(1);
            }
        }
        void CheckFire()
        {
            //Set currentWeapon to attachedWeapon[weaponindex]
            Weapon currentWeapon = attachedWeapon[weaponIndex];
            //if space is down
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //fire currentWeapon
                currentWeapon.Fire();
                //apply currentWeapon's recoil to player
                rb.AddForce(-transform.right * currentWeapon.recoil, ForceMode2D.Impulse);
            }
        }
        Weapon SwitchWeapon(int weaponIndex)
        {
            //check bounds
            if (weaponIndex < 0 || weaponIndex > attachedWeapon.Length)
            {
                return null;
            }
            //loop through all attackedweapons
            for (int i = 0; i < attachedWeapon.Length; i++)
            {
                //set w to attachedWeapons[weaponindex]
                //w = attackedWeapon[i]
                //w is class weapon
                Weapon w = attachedWeapon[i];
                //if i == weapon index
                if (i == weaponIndex)
                {
                    // activate gameobject in w variable
                    w.gameObject.SetActive(true);
                }
                else
                {
                    //deactivate gameobject in w variable  
                    w.gameObject.SetActive(false);
                }

            }

            return attachedWeapon[weaponIndex];
        }

        // Update is called once per frame

    }

}
