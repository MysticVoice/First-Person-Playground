using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public class MovementStateMachine : MonoBehaviour
    {
        BaseMovementState currentState;

        public GroundedState groundedState = new GroundedState();
        public JumpState jumpState = new JumpState();
        public FallingState fallingState = new FallingState();
        public CoyoteState coyoteState = new CoyoteState();
        public DashState dashState = new DashState();

        void Start()
        {
            SwitchState(groundedState);
        }

        void FixedUpdate()
        {
            currentState.UpdateState(this);
        }

        public void SwitchState(BaseMovementState state)
        {
            currentState = state;
            currentState.GetController(this);
            currentState.EnterState(this);
        }
    }
}
