public abstract class WeaponBaseState
{
    public HeldItemInputs held;
    public Weapon weapon;
    public abstract void EnterState(WeaponStateMachine stateMachine);
    public abstract void UpdateState(WeaponStateMachine stateMachine);
    public void GetController(WeaponStateMachine stateMachine)
    {
        held = stateMachine.GetComponentInParent<HeldItemInputs>();
        weapon = stateMachine.GetComponent<Weapon>();
    }
}
