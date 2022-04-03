using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Transform spawnPoint = (FindObjectOfType(typeof(SpawnPoint)) as SpawnPoint).transform;
            other.transform.position = spawnPoint.position;
            other.transform.rotation = spawnPoint.rotation;
            ExpandedCharacterController cc = other.GetComponent<ExpandedCharacterController>();
            cc.skipFrame = true;
        }
        
    }
}
