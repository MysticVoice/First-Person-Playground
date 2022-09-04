using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MysticVoice.Core;

namespace MysticVoice
{
    public class TestInteractible : BaseInteractible
    {

        public void Awake()
        {
            SetInteractionRangeState(false);
        }

        public override void Interact()
        {
            print(text + " " + gameObject.name);
        }

        public override void SetInteractionRangeState(bool state)
        {
            foreach (Transform t in GetComponentsInChildren<Transform>(includeInactive: true))
            {
                if (t != this.transform) t.gameObject.SetActive(state);
            }
        }
    }
}
