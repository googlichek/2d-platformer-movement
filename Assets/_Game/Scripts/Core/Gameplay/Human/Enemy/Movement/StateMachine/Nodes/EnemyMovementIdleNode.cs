namespace Game.Scripts.Core
{
    public class EnemyMovementIdleNode : BaseEntityNode<MovementState>
    {
        private HumanController _owner = default;

        public EnemyMovementIdleNode(MovementState state) : base(state)
        {
        }

        public void Setup(HumanController owner)
        {
            _owner = owner;
        }

        public override void Enter(MovementState from)
        {
            base.Enter(from);

            if (from == MovementState.Fall ||
                from == MovementState.Jump)
            {
                _owner.DustParticlesComponent.Emit();
            }
        }

        protected override void UpdateNextState()
        {
            NextState = MovementState.Walk;
        }

        protected override void UpdateNodeState()
        {
            if (_owner.GunComponent.IsInUse ||
                _owner.MeleeComponent.IsInUse)
                return;

            _owner.AnimationComponent.SetState(AnimationStates.Idle);
        }
    }
}
