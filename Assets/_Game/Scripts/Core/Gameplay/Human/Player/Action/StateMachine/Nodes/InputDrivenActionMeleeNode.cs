namespace Game.Scripts.Core
{
    public class InputDrivenActionMeleeNode : BaseEntityNode<ActionState>
    {
        private HumanController _owner = default;
        private InputWrapper _inputWrapper = default;

        public InputDrivenActionMeleeNode(ActionState state) : base(state)
        {
        }

        public void Setup(HumanController owner, InputWrapper inputWrapper)
        {
            _owner = owner;
            _inputWrapper = inputWrapper;
        }

        public override void Enter(ActionState from)
        {
            base.Enter(from);

            _owner.MeleeComponent.Use();
        }

        protected override void UpdateNextState()
        {
            if (_owner.MeleeComponent.IsInUse)
                return;

            NextState = ActionState.Idle;
        }

        protected override void UpdateNodeState()
        {
            if (!_owner.MeleeComponent.IsInUse)
                return;

            _owner.AnimationComponent.SetState(AnimationStates.Melee);
        }
    }
}
