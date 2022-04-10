using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Respawn(other.transform);
        }
        
    }

    public void Respawn(Transform player)
    {
        Transform spawnPoint = (FindObjectOfType(typeof(SpawnPoint)) as SpawnPoint).transform;
        player.position = spawnPoint.position;
        player.rotation = spawnPoint.rotation;
        ExpandedCharacterController cc = player.GetComponent<ExpandedCharacterController>();
        cc.skipFrame = true;
    }
}
