using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class WeaponCooldownState : WeaponBaseState
    {
        private float cooldownTimer;
        public override void EnterState(WeaponStateMachine weaponState)
        {
            cooldownTimer = weapon.GetNextFireTime(weapon.fireRate);
        }

        public override void UpdateState(WeaponStateMachine weaponState)
        {
            if (CheckCooldownTimer()) weaponState.SwitchState(weaponState.idleState);
        }

        public bool CheckCooldownTimer()
        {
            return Time.time >= cooldownTimer;
        }
    }
}
