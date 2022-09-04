using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MysticVoice
{
    public class ButtonPressReciever : MonoBehaviour, IReturnButtonPresses
    {
        public List<InputActionReference> buttons;

        private void Start()
        {
            foreach (InputActionReference iar in buttons)
            {
                iar.action.Enable();
            }
        }

        public bool GetBinaryButton(int i)
        {
            return buttons[i].action.ReadValue<float>() > 0;
        }

        public float GetFloatingButton(int i)
        {
            return buttons[i].action.ReadValue<float>();
        }

        public Vector2 GetVector2Button(int i)
        {
            return buttons[i].action.ReadValue<Vector2>();
        }
    }
}
