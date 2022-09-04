using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MysticVoice
{
    public class ConditionEvent : MonoBehaviour, IHaveACondition
    {
        public IHaveACondition condition;
        public UnityEvent ConditionSuccess;
        public UnityEvent ConditionFail;

        public bool CheckCondition()
        {
            bool success = condition.CheckCondition();
            if (success) ConditionSuccess?.Invoke();
            else ConditionFail?.Invoke();
            return success;
        }
    }
}
