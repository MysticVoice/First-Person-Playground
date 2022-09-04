using UnityEngine;

namespace MysticVoice
{
    public class GroundedState : BaseMovementState
    {
        public override void EnterState(MovementStateMachine movement)
        {
            character.momentum.y = 0;
            character.GroundedDownForce();
            character.ResetJumps();
        }

        public override void UpdateState(MovementStateMachine movement)
        {
            character.StandardMovement();
            character.GroundedDownForce();
            if (!character.IsGrounded()) movement.SwitchState(movement.coyoteState);
            else if (character.playerJumpedThisFrame && character.CanJump()) movement.SwitchState(movement.jumpState);

        }
    }
}
