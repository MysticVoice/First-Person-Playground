using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : BaseMovementState
{
    private int dashCounter;
    public override void EnterState(MovementStateMachine movement)
    {
        character.momentum = Vector3.zero;
        character.momentum = Vector3.zero;
        dashCounter = character.dashFrames;
    }

    public override void UpdateState(MovementStateMachine movement)
    {
        if (dashCounter <= 0) movement.SwitchState(movement.fallingState);
        else
        {
            dashCounter--;
            character.movement = character.lookDirection.TransformVector(Vector3.forward * character.playerSpeed * character.dashMultiplier * Time.fixedDeltaTime);
        }
    }
}
