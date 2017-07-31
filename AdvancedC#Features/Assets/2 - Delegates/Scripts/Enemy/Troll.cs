using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delagates
{
    public class Troll : Enemy
    {
        public float attackRange = 2f;
        public float meleeSpeed = 20f;
        public float meleeDelay = 0.3f;
        public GameObject attackBox;
        private bool isAttacking = false;

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            //if is not attacking and target within range
            if (!isAttacking && IsCloseToTarget(attackRange))
            {
                Attack();
            }
        }
        IEnumerator Attack()
        {
            //During attack is this section
            isAttacking = true;
            attackBox.SetActive(true);
            behaviourIndex = Behaviour.IDLE;
            yield return new WaitForSeconds(meleeDelay);
            //After attack
            behaviourIndex = Behaviour.SEEK;
            attackBox.SetActive(false);
            isAttacking = false;
        }
    }

}

