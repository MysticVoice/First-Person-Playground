using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice.Core
{
    public interface IInteractible
    {
        public void Interact();
        public void SetInteractionRangeState(bool state);
        public string GetInteractionText();
    }
}
