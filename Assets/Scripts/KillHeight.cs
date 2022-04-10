using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillHeight : MonoBehaviour
{
    public float killHeight = -3;
    public Transform player;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.y < killHeight)
        {
            GetComponent<RespawnPlayer>().Respawn(player);
        }
    }
}
