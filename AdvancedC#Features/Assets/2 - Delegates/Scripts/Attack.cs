using Delagates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delagetes
{

    public class Attack : MonoBehaviour
    {
        public int damage = 10;
        protected virtual void OnTriggerEnter(Collider other)
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                //Deal Damage on the object
                health.TakeDamage(damage);
            }
        }
    }

}
