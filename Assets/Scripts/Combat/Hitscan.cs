using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class Hitscan
    {
        public static void Fire(Transform origin, out RaycastHit hit) => Physics.Raycast(origin.position, origin.forward, out hit, 1000);
    }
}