using UnityEngine;

public abstract class BaseMovementState
{
    public ExpandedCharacterController character;
    public abstract void EnterState(MovementStateMachine movement);
    public abstract void UpdateState(MovementStateMachine movement);
    public void GetController(MovementStateMachine movement)
    {
        character = movement.GetComponent<ExpandedCharacterController>();
    }
}
