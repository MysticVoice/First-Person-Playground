using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public interface IHaveACondition
    {
        public bool CheckCondition();
        public bool CheckCondition(Transform caller);
    }
}
