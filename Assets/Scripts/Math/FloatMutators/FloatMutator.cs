using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FloatMutator : ScriptableObject
{
    public abstract float Calculate(float value);
}
