namespace Game.Scripts.Core
{
    public class EnemyActionStateMachineComponent : BaseStateMachineComponent<ActionState>
    {
        private HumanController _owner = default;

        public void Setup(HumanController owner)
        {
            _owner = owner;
        }

        public override void Enable()
        {
            CreateNode<EnemyActionIdleNode>(ActionState.Idle).Setup(_owner);

            ResetState();
        }

        protected override void ResetState()
        {
            currentState = ActionState.Idle;
            base.ResetState();
        }
    }
}
