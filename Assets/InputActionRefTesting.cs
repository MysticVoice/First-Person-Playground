using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MysticVoice
{
    public class InputActionRefTesting : MonoBehaviour
    {
        IReturnButtonPresses inputs;
        private void Start()
        {
            inputs = GetComponent<IReturnButtonPresses>();
        }
    }
}
