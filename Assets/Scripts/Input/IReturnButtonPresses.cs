using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public interface IReturnButtonPresses
    {
        public bool GetBinaryButton(int i);
        public float GetFloatingButton(int i);
        public Vector2 GetVector2Button(int i);
    }
}
