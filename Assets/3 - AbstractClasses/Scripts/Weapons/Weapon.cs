using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class Weapon : MonoBehaviour
    {
        public GameObject muzzleFlash;
        public GameObject bulletPrefab;
        public int damage = 10;
        public int ammo = 0;
        public int maxAmmo = 30;
        public float recoil = 5f;
        public float fireInterval = 0.2f;
        public bool isReady = true;

        public abstract void Fire();
        public virtual void Reload()
        {
            ammo = maxAmmo;
        }

        public Bullet SpawnBullet(Vector3 pos, Quaternion rotation)
        {
            //Insttanciate a new bullet
            GameObject clone = Instantiate(bulletPrefab, pos, rotation);
            Bullet b = clone.GetComponent<Bullet>();
            // play sound here
            //play muzzle flash
            Instantiate(muzzleFlash, pos, rotation);
            //Reduce current ammo -1
            ammo--;
            //return that new bullet
            return b;
        }
    }


}
