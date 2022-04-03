using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdleState : WeaponBaseState
{
    public override void EnterState(WeaponStateMachine weaponState)
    {
        
    }

    public override void UpdateState(WeaponStateMachine stateMachine)
    {
        if (held.use) stateMachine.SwitchState(stateMachine.fireState);
    }
}
