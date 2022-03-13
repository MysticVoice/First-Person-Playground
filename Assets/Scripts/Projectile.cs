using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int framesUntilDeath = 120;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (framesUntilDeath <= 0) Destroy(this.gameObject);
        transform.position+=transform.forward*speed;
        framesUntilDeath--;
    }
}
