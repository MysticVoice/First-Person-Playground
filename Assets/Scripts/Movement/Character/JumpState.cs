using UnityEngine;

namespace MysticVoice
{
    public class JumpState : BaseMovementState
    {
        public override void EnterState(MovementStateMachine movement)
        {
            character.Jump();
            character.playerJumpedThisFrame = false;
            character.movement.y = 0;
        }

        public override void UpdateState(MovementStateMachine movement)
        {
            character.StandardMovement();
            movement.SwitchState(movement.fallingState);
        }
    }
}
