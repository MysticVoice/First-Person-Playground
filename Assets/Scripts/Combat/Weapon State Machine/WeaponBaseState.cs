namespace MysticVoice
{
    public abstract class WeaponBaseState
    {
        public Weapon weapon;
        public abstract void EnterState(WeaponStateMachine stateMachine);
        public abstract void UpdateState(WeaponStateMachine stateMachine);
        public void GetController(WeaponStateMachine stateMachine)
        {
            weapon = stateMachine.GetComponent<Weapon>();
        }
    }
}
