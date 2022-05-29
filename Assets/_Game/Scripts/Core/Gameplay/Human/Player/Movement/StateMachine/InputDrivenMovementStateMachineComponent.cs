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
            CreateNode<InputDrivenIdleNode>(MovementState.Idle).Setup(_owner, _inputWrapper, _cameraOperator);
            CreateNode<InputDrivenWalkNode>(MovementState.Walk).Setup(_owner, _inputWrapper, _cameraOperator);
            CreateNode<InputDrivenCrouchNode>(MovementState.Crouch).Setup(_owner, _inputWrapper, _cameraOperator);
            CreateNode<InputDrivenJumpNode>(MovementState.Jump).Setup(_owner, _inputWrapper, _cameraOperator);
            CreateNode<InputDrivenFallNode>(MovementState.Fall).Setup(_owner, _inputWrapper, _cameraOperator);

            ResetState();
        }

        protected override void ResetState()
        {
            currentState = MovementState.Idle;
            base.ResetState();
        }
    }
}
