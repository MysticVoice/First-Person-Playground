using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class DashState : BaseMovementState
    {
        private int dashCounter;
        public override void EnterState(MovementStateMachine movement)
        {
            character.SetMovement(Vector3.zero);
            character.SetMomentum(Vector3.zero);
            dashCounter = character.dashFrames;
        }

        public override void UpdateState(MovementStateMachine movement)
        {
            if (dashCounter <= 0) movement.SwitchState(movement.fallingState);
            else
            {
                dashCounter--;
                character.SetMovement(character.lookDirection.TransformVector(Vector3.forward * character.playerSpeed * character.dashMultiplier * Time.fixedDeltaTime));
            }
        }
    }
}
