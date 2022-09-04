using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    [CreateAssetMenu(fileName = "Scriptable Bool Event", menuName = "Scriptable Objects/Events/Scriptable Bool Event")]
    public class ScriptableBoolEvent : ScriptableObject
    {
        public event System.Action<bool> OnTrigger;
        public bool value = false;

        public void trigger(bool value)
        {
            OnTrigger?.Invoke(value);
            this.value = value;
        }
    }
}
