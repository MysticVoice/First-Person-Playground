using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class WeaponIdleState : WeaponBaseState
    {
        public override void EnterState(WeaponStateMachine weaponState)
        {

        }

        public override void UpdateState(WeaponStateMachine stateMachine)
        {
            if (weapon.inputs.GetBinaryButton(0)) stateMachine.SwitchState(stateMachine.fireState);
            if (weapon.inputs.GetBinaryButton(1)) stateMachine.SwitchState(stateMachine.reloadState);
        }
    }
}
