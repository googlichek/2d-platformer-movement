using Game.Scripts.Utils;

namespace Game.Scripts.Core
{
    public class InputDrivenIdleNode : BaseEntityNode<MovementState>
    {
        private HumanController _owner = default;

        private InputWrapper _inputWrapper = default;

        public InputDrivenIdleNode(MovementState state) : base(state)
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
                NextState = MovementState.Crouch;
            }

            if (_owner.MovementComponent.Velocity.y < 0 &&
                !_owner.RaycastComponent.HasGround)
            {
                NextState = MovementState.Fall;
            }

            if (_inputWrapper.IsJumpPressed &&
                !_owner.MovementComponent.AreConsecutiveJumpsDepleted)
            {
                NextState = MovementState.Jump;
            }
        }

        protected override void UpdateNodeState()
        {
            _owner.AnimationComponent.SetState(AnimationStates.Idle);
        }
    }
}
