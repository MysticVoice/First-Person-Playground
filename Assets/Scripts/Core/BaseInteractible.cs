using MysticVoice.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice.Core
{
    public class BaseInteractible : MonoBehaviour, IInteractible
    {
        public string text;
        public bool dissabledByDefault;

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
        private void OnEnable()
        {
            if (!dissabledByDefault) AddToInteractionSystem();
        }

        private void OnDisable()
        {
            RemoveFromInteractionSystem();
        }

        public void AddToInteractionSystem()
        {
            InteractionSystem.instance.AddInteractible(this as IInteractible);
        }

        protected void RemoveFromInteractionSystem()
        {
            InteractionSystem interactionSystem = InteractionSystem.instance;
            interactionSystem.RemoveInteractible(this);
        }
    }
}