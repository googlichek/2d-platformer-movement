namespace Game.Scripts.Core
{
    public class InputDrivenActionIdleNode : BaseEntityNode<ActionState>, IHumanActionNode
    {
        private HumanController _owner = default;
        private InputWrapper _inputWrapper = default;

        public InputDrivenActionIdleNode(ActionState state) : base(state)
        {
        }

        public void Setup(HumanController owner, InputWrapper inputWrapper)
        {
            _owner = owner;
            _inputWrapper = inputWrapper;
        }

        protected override void UpdateNextState()
        {
            if (_inputWrapper.IsWeaponUsePressed)
            {
                if (_owner.MovementStateMachineComponent.ActiveState == MovementState.Idle ||
                    _owner.MovementStateMachineComponent.ActiveState == MovementState.Crouch)
                {
                    NextState = ActionState.IdleShoot;
                }

                if (_owner.MovementStateMachineComponent.ActiveState == MovementState.Walk)
                {
                    NextState = ActionState.Melee;
                }
            }
        }

        protected override void UpdateNodeState()
        {
        }
    }
}
