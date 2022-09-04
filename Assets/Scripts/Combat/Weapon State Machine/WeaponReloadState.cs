using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class WeaponReloadState : WeaponBaseState
    {
        float reloadTimer;
        public override void EnterState(WeaponStateMachine weaponState)
        {
            reloadTimer = weapon.GetNextReloadTime(weapon.reloadTime);
            weaponState.reloadEvent?.Invoke();
        }

        public override void UpdateState(WeaponStateMachine weaponState)
        {
            if (CheckReloadTimer())
            {
                weapon.FillMagazine();
                weaponState.SwitchState(weaponState.idleState);
            }
        }

        public bool CheckReloadTimer()
        {
            return Time.time >= reloadTimer;
        }
    }
}
