using Game.Scripts.Utils;

namespace Game.Scripts.Core
{
    public class InputDrivenWalkNode : BaseEntityNode<MovementState>
    {
        private HumanController _owner = default;

        private InputWrapper _inputWrapper = default;

        public InputDrivenWalkNode(MovementState state) : base(state)
        {
        }

        public void Setup(HumanController owner, InputWrapper inputWrapper)
        {
            _owner = owner;
            _inputWrapper = inputWrapper;
        }

        protected override void UpdateNextState()
        {
            if (_inputWrapper.Horizontal.IsEqual(0))
            {
                NextState =
                    _inputWrapper.IsCrouchPressed
                        ? MovementState.Crouch
                        : MovementState.Idle;
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
            _owner.MovementComponent.SetMovementDirection(_inputWrapper.Horizontal);
            _owner.AnimationComponent.SetState(AnimationStates.Run);
        }
    }
}
