using MysticVoice.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice.Core
{
    public class BaseInteractible : MonoBehaviour, IInteractible
    {
        public string text;

        public virtual string GetInteractionText()
        {
            return text;
        }

        public virtual void Interact() { }

        public virtual void HeldInteraction(bool value) { }

        public virtual void SetEnabled()
        {
            enabled = false;
        }

        public virtual void SetInteractionRangeState(bool state) { }

        public virtual bool IsEnabled()
        {
            return enabled;
        }
    }
}