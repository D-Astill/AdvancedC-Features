using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Recursion
{
    public class RecursiveSpawner : MonoBehaviour
    {
        public GameObject spawnPrefab;
        public int amount = 100;
        public float posOffset = 5f;
        public float scaleFactor = 0.70f;

        void RecursiveSpawn(int currentAmount, Vector3 pos, Vector3 scale)
        {
            amount--;
            if (amount <= 0)
                return;
            Vector3 adjustedScale = scale * (1 - scaleFactor);
            Vector3 adjustedPos = pos + Vector3.up * adjustedScale.magnitude;

            GameObject clone = Instantiate(spawnPrefab);
            clone.transform.position = adjustedPos;
            clone.transform.localScale = adjustedScale;

            RecursiveSpawn(amount, adjustedPos, adjustedScale);
        }
        // Use this for initialization
        void Start()
        {
            Vector3 pos = transform.position;
            Vector3 scale = spawnPrefab.transform.localScale;
            RecursiveSpawn(amount, pos, scale);
        }
        
    }

}
