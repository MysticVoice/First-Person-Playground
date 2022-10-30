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
            if (weapon.fireInput) stateMachine.SwitchState(stateMachine.fireState);
            if (weapon.reloadInput) stateMachine.SwitchState(stateMachine.reloadState);
        }
    }
}
