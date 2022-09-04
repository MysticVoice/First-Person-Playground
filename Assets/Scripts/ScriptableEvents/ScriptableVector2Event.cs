using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MysticVoice
{
    [CreateAssetMenu(fileName = "Scriptable Vector2 Event", menuName = "Scriptable Objects/Events/Scriptable Vector2 Event")]
    public class ScriptableVector2Event : ScriptableObject
    {
        public event System.Action<Vector2> OnTrigger;
        public Vector2 value = Vector2.zero;

        public void trigger(Vector2 value)
        {
            OnTrigger?.Invoke(value);
            this.value = value;
        }
    }
}
