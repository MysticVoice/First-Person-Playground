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
        public int spawnCap = 5;
        private List<GameObject> spawned;

        public List<GameObject> Spawned { 
            get { 
                if (spawned == null) { spawned = new List<GameObject>(); }
                return spawned; 
            } 
        }

        public void Spawn()
        {
            PruneDestroyedObjects();
            if(Spawned.Count>=spawnCap) { return; }
            GameObject temp = Instantiate(prefab);
            temp.transform.position = this.transform.position + new Vector3(Random.Range(-range, range), 0, Random.Range(-range,range));
            Spawned.Add(temp);
        }

        private void PruneDestroyedObjects()
        {
            Spawned.RemoveAll(item => item == null);
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
