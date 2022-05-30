namespace Game.Scripts.Core
{
    public class EnemyMovementStateMachineComponent : BaseStateMachineComponent<MovementState>
    {
        private HumanController _owner = default;

        public void Setup(HumanController owner)
        {
            _owner = owner;
        }

        public override void Enable()
        {
            CreateNode<EnemyMovementIdleNode>(MovementState.Idle).Setup(_owner);
            CreateNode<EnemyMovementWalkNode>(MovementState.Walk).Setup(_owner);
            CreateNode<EnemyMovementFallNode>(MovementState.Fall).Setup(_owner);

            ResetState();
        }

        protected override void ResetState()
        {
            currentState = MovementState.Idle;
            base.ResetState();
        }
    }
}
