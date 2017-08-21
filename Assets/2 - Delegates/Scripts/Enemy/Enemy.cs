using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Delagates
{
    public abstract class Enemy : MonoBehaviour
    {
        public enum Behaviour
        {
            IDLE = 0,
            SEEK = 1,
            FLEE = 2,
            DEATH= 3
        }

        delegate void BehaviourFunc();
        public Transform target;
        public Behaviour behaviourIndex = Behaviour.SEEK;
        private List<BehaviourFunc> behavioursFuncs = new List<BehaviourFunc>();
        private NavMeshAgent agent;
        // Use this for initialization
        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            //Assign Delagates to list here 
            behavioursFuncs.Add(Idle);
            behavioursFuncs.Add(Seek);
            behavioursFuncs.Add(Flee);
            behavioursFuncs.Add(Death);
        }
        void Idle()
        {
            agent.Stop();
        }
        void Seek()
        {
            agent.Resume();
            if (target != null)
            {
                agent.SetDestination(target.position);
            }
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
        public bool IsCloseToTarget(float distance)
        {
            //if Target is != null
            if (target != null)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                //if disttotarget is less than or equal to distance
                if (distToTarget <= distance)
                {
                    return true;
                }

            }
            return false;
                
                     
        }
        void Flee()
        {

        }
        void Death()
        {

        }
        // Update is called once per frame
        protected virtual void Update()
        {
            //call the correct delagate function 
            behavioursFuncs[(int)behaviourIndex]();
        }
    }

}
