using Game.Scripts.Utils;

namespace Game.Scripts.Core
{
    public class InputDrivenMovementCrouchNode : BaseEntityNode<MovementState>
    {
        private HumanController _owner = default;
        private InputWrapper _inputWrapper = default;
        private CameraOperator _cameraOperator = default;

        public InputDrivenMovementCrouchNode(MovementState state) : base(state)
        {
        }

        public void Setup(HumanController owner, InputWrapper inputWrapper, CameraOperator cameraOperator)
        {
            _owner = owner;
            _inputWrapper = inputWrapper;
            _cameraOperator = cameraOperator;
        }

        protected override void UpdateNextState()
        {
            if (!_inputWrapper.Horizontal.IsEqual(0))
            {
                NextState = MovementState.Walk;
            }

            if (_inputWrapper.IsCrouchPressed ||
                _inputWrapper.IsWeaponUsePressed)
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
