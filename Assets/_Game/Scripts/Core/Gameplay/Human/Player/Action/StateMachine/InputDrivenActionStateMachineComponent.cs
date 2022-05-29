using Zenject;

namespace Game.Scripts.Core
{
    public class InputDrivenActionStateMachineComponent : BaseStateMachineComponent<ActionState>
    {
        private InputWrapper _inputWrapper = default;
        private HumanController _owner = default;

        [Inject]
        public void Construct(InputWrapper inputWrapper)
        {
            _inputWrapper = inputWrapper;
        }

        public void Setup(HumanController owner)
        {
            _owner = owner;
        }

        public override void Enable()
        {
            CreateNode<InputDrivenActionIdleNode>(ActionState.Idle).Setup(_owner, _inputWrapper);
            CreateNode<InputDrivenActionIdleShotNode>(ActionState.IdleShoot).Setup(_owner, _inputWrapper);

            ResetState();
        }

        protected override void ResetState()
        {
            currentState = ActionState.Idle;
            base.ResetState();
        }
    }
}
