using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public abstract class FloatMutator : ScriptableObject
    {
        public abstract float Calculate(float value);
    }
}
