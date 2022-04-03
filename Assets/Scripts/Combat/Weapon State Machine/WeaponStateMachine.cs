using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine : MonoBehaviour
{
    WeaponBaseState currentState;
    public WeaponIdleState idleState = new WeaponIdleState();
    public WeaponFireState fireState = new WeaponFireState();
    public WeaponCooldownState cooldownState = new WeaponCooldownState();
    public WeaponReloadState reloadState = new WeaponReloadState();
    private void Start()
    {
        SwitchState(idleState);
    }
    private void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(WeaponBaseState state)
    {
        currentState = state;
        currentState.GetController(this);
        currentState.EnterState(this);
    }
}
