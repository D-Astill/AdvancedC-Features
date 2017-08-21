using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Delagates
{

    public class EnemySpawner : MonoBehaviour
    {
        public Transform target;
        public GameObject orcPrefab, trollPrefab;
        public int minAmount = 0, maxAmount = 20, currentAmount;
        public float spawnRate = 1f;

        delegate void SpawnerFunc(int amount);
        private List<SpawnerFunc> spawnerFunc = new List<SpawnerFunc>();
        private int enemySpawn;

        void Awake()
        {
            //Assign Delagates to list here 
        }

        IEnumerator SpawnerFuntion(int num)
        {
            if (num == 1)
            {
                SpawnOrc(1);
                enemySpawn++;
                yield return null;
            }
            else 
            {
                enemySpawn++;
                SpawnTroll(1);
                yield return null;
            }
            
        }

        void SpawnOrc(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(orcPrefab);
               
            }
        }

        void SpawnTroll(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(trollPrefab);
            }
        }

        void Update()
        {
            if (currentAmount > maxAmount)
            {
                SpawnerFuntion(Random.Range(1,2));
            }
        }
    }

}
