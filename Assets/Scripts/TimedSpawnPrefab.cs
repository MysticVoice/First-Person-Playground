using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class TimedSpawnPrefab : MonoBehaviour
    {
        public GameObject prefab;
        public float spawnTime;
        private float nextSpawn;
        public float range;

        public void Spawn()
        {
            GameObject temp = Instantiate(prefab);
            temp.transform.position = this.transform.position + new Vector3(Random.RandomRange(-range, range), 0, Random.RandomRange(-range,range));
            ResetTimer();
        }

        private void FixedUpdate()
        {
            if(nextSpawn<Time.time)
            {
                Spawn();
                ResetTimer();
            }
        }

        private void ResetTimer()
        {
            nextSpawn = Time.time + spawnTime;
        }
    }
}
