using UnityEngine;

namespace Game.Scripts.Core
{
    public class EnemyMovementFallNode : BaseEntityNode<MovementState>
    {
        private HumanController _owner = default;

        private int _movementDirection = -1;

        public EnemyMovementFallNode(MovementState state) : base(state)
        {
        }

        public void Setup(HumanController owner)
        {
            _owner = owner;
        }

        public override void Enter(MovementState from)
        {
            base.Enter(from);

            _movementDirection = Mathf.FloorToInt(_owner.transform.localScale.x);
        }

        protected override void UpdateNextState()
        {
            if (_owner.RaycastComponent.HasGround)
            {
                NextState = MovementState.Walk;
            }
        }

        protected override void UpdateNodeState()
        {
            if (_owner.MeleeComponent.IsInUse)
                return;

            _owner.MovementComponent.SetMovementDirection(_movementDirection);
            _owner.AnimationComponent.SetState(AnimationStates.Fall);
        }
    }
}
