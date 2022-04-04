using UnityEngine;

public class CoyoteState : BaseMovementState
{
    public int coyoteCounter;

    public override void EnterState(MovementStateMachine movement)
    {
        coyoteCounter = character.coyoteFrames;
        character.SteppedOffLedge();
    }

    public override void UpdateState(MovementStateMachine movement)
    {
        character.StandardMovement();
        if (character.IsGrounded()) movement.SwitchState(movement.groundedState);
        else if (coyoteCounter <= 0) movement.SwitchState(movement.fallingState);
        else if (character.playerJumpedThisFrame && character.CanJump()) movement.SwitchState(movement.jumpState);
        else
        {
            
            coyoteCounter--;
        }
    }
}
