using Zenject;

namespace Game.Scripts.Core
{
    public class InputDrivenMovementStateMachineComponent : BaseStateMachineComponent<MovementState>
    {
        private InputWrapper _inputWrapper = default;
        private CameraOperator _camera = default;

        private HumanController _owner = default;

        [Inject]
        public void Construct(InputWrapper inputWrapper, CameraOperator cameraOperator)
        {
            _inputWrapper = inputWrapper;
            _camera = cameraOperator;
        }

        public void Setup(HumanController owner)
        {
            _owner = owner;
        }

        public override void Enable()
        {
            CreateNode<InputDrivenIdleNode>(MovementState.Idle).Setup(_owner, _inputWrapper);
            CreateNode<InputDrivenWalkNode>(MovementState.Walk).Setup(_owner, _inputWrapper);
            CreateNode<InputDrivenCrouchNode>(MovementState.Crouch).Setup(_owner, _inputWrapper);
            CreateNode<InputDrivenJumpNode>(MovementState.Jump).Setup(_owner, _inputWrapper);
            CreateNode<InputDrivenFallNode>(MovementState.Fall).Setup(_owner, _inputWrapper);

            ResetState();
        }

        protected override void ResetState()
        {
            currentState = MovementState.Idle;
            base.ResetState();
        }
    }
}
