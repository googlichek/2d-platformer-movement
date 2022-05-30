namespace Game.Scripts.Core
{
    public class InputDrivenMovementFallNode : BaseEntityNode<MovementState>
    {
        private HumanController _owner = default;
        private InputWrapper _inputWrapper = default;
        private CameraOperator _cameraOperator = default;

        public InputDrivenMovementFallNode(MovementState state) : base(state)
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
            if (_owner.RaycastComponent.HasGround)
            {
                NextState = MovementState.Walk;
            }

            if (_inputWrapper.IsJumpPressed &&
                !_owner.MovementComponent.AreConsecutiveJumpsDepleted)
            {
                NextState = MovementState.Jump;
            }
        }

        protected override void UpdateNodeState()
        {
            if (_owner.MeleeComponent.IsInUse)
                return;

            _owner.MovementComponent.SetMovementDirection(_inputWrapper.Horizontal);
            _owner.AnimationComponent.SetState(AnimationStates.Fall);
        }
    }
}
