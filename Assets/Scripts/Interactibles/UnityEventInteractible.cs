using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using MysticVoice.Core;

namespace MysticVoice
{
    public class UnityEventInteractible : BaseInteractible
    {
        public UnityEvent interactionEvent;
        public UnityAction<bool> heldEvent;
        public void Awake()
        {
            SetInteractionRangeState(false);
        }

        public override void Interact()
        {
            interactionEvent?.Invoke();
        }

        /*public override void HeldInteraction(bool value)
        {
            heldEvent?.Invoke(value);
        }*/

        public override void SetInteractionRangeState(bool state)
        {
            foreach (TextMeshPro t in GetComponentsInChildren<TextMeshPro>(includeInactive: true))
            {
                t.gameObject.SetActive(state);
            }
        }
    }
}
