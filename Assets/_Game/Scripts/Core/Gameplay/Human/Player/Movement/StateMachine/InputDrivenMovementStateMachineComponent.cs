using Zenject;

namespace Game.Scripts.Core
{
    public class InputDrivenMovementStateMachineComponent : BaseStateMachineComponent<MovementState>
    {
        private InputWrapper _inputWrapper = default;
        private CameraOperator _cameraOperator = default;

        private HumanController _owner = default;

        [Inject]
        public void Construct(InputWrapper inputWrapper, CameraOperator cameraOperator)
        {
            _inputWrapper = inputWrapper;
            _cameraOperator = cameraOperator;
        }

        public void Setup(HumanController owner)
        {
            _owner = owner;
        }

        public override void Enable()
        {
            CreateNode<InputDrivenMovementIdleNode>(MovementState.Idle).Setup(_owner, _inputWrapper, _cameraOperator);
            CreateNode<InputDrivenMovementWalkNode>(MovementState.Walk).Setup(_owner, _inputWrapper, _cameraOperator);
            CreateNode<InputDrivenMovementCrouchNode>(MovementState.Crouch).Setup(_owner, _inputWrapper, _cameraOperator);
            CreateNode<InputDrivenMovementJumpNode>(MovementState.Jump).Setup(_owner, _inputWrapper, _cameraOperator);
            CreateNode<InputDrivenMovementFallNode>(MovementState.Fall).Setup(_owner, _inputWrapper, _cameraOperator);

            ResetState();
        }

        protected override void ResetState()
        {
            currentState = MovementState.Idle;
            base.ResetState();
        }
    }
}
