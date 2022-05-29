using Game.Scripts.Utils;

namespace Game.Scripts.Core
{
    public class InputDrivenCrouchNode : BaseEntityNode<MovementState>
    {
        private HumanController _owner = default;

        private InputWrapper _inputWrapper = default;

        public InputDrivenCrouchNode(MovementState state) : base(state)
        {
        }

        public void Setup(HumanController owner, InputWrapper inputWrapper)
        {
            _owner = owner;
            _inputWrapper = inputWrapper;
        }

        protected override void UpdateNextState()
        {
            if (!_inputWrapper.Horizontal.IsEqual(0))
            {
                NextState = MovementState.Walk;
            }

            if (_inputWrapper.IsCrouchPressed)
            {
                NextState = MovementState.Idle;
            }

            if (_inputWrapper.IsJumpPressed &&
                !_owner.MovementComponent.AreConsecutiveJumpsDepleted)
            {
                NextState = MovementState.Jump;
            }
        }

        protected override void UpdateNodeState()
        {
            _owner.MovementComponent.SetMovementDirection(0);
            _owner.AnimationComponent.SetState(AnimationStates.Crouch);
        }
    }
}
