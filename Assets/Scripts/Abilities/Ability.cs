using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public abstract class Ability : ScriptableObject, IUseable
    {
        public abstract void Use(MonoBehaviour context);
    }
}
