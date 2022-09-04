using UnityEngine;

namespace MysticVoice
{
    public class FallingState : BaseMovementState
    {
        public override void EnterState(MovementStateMachine movement)
        {

        }

        public override void UpdateState(MovementStateMachine movement)
        {
            character.StandardMovement();
            if (character.IsGrounded()) movement.SwitchState(movement.groundedState);
            else if (character.playerJumpedThisFrame && character.CanJump()) movement.SwitchState(movement.jumpState);
            else character.Fall();
        }
    }
}
