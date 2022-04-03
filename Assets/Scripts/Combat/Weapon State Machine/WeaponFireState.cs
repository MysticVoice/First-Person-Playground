using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireState : WeaponBaseState
{
    public override void EnterState(WeaponStateMachine weaponState)
    {
        if (!weapon.MagHasBullets()) weaponState.SwitchState(weaponState.reloadState);
    }

    public override void UpdateState(WeaponStateMachine weaponState)
    {
        weapon.Fire(true);
        weaponState.SwitchState(weaponState.cooldownState);
    }
}
