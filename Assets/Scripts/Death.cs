using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class Death : MonoBehaviour
    {
        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
