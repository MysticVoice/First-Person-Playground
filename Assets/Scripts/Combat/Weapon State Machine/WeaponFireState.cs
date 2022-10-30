using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class WeaponFireState : WeaponBaseState
    {
        public override void EnterState(WeaponStateMachine weaponState)
        {
            if (!weapon.MagHasBullets()) weaponState.SwitchState(weaponState.reloadState);
            else weaponState.FireEvent?.Invoke();
            
        }

        public override void UpdateState(WeaponStateMachine weaponState)
        {
            weapon.ResetInputs();
            weapon.Fire(true);
            weaponState.SwitchState(weaponState.cooldownState);
        }
    }
}
