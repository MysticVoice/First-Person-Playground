using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    [CreateAssetMenu(fileName ="SpawnObject",menuName ="Create/Ability/SpawnObject")]
    public class SpawnObject : Ability
    {
        [SerializeField]
        GameObject spawnable;

        public override void Use(MonoBehaviour context)
        {
            spawnObject(context.GetComponentInChildren<FirePoint>());
        }

        private void spawnObject(FirePoint fp)
        {
            Instantiate(spawnable,fp.transform);
            
        }
    }

    
}
