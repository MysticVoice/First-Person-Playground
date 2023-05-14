using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    [CreateAssetMenu(fileName = "Trail Config", menuName = "Guns/Trail Configuration", order = 3)]
    public class TrailConfigScriptableObject : ScriptableObject
    {
        public Material material;
        public AnimationCurve widthCurve;
        public float duration;
        public float minVertexDistance = 0.1f;
        public Gradient color;
        public float missDistance = 100f;
        public float simulationSpeed = 100f;

    }
}
