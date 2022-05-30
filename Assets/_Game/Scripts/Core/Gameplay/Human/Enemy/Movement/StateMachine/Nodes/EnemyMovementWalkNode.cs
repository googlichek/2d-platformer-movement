using UnityEngine;

namespace Game.Scripts.Core
{
    public class EnemyMovementWalkNode : BaseEntityNode<MovementState>
    {
        private HumanController _owner = default;

        private int _movementDirection = -1;

        private float _directionChangeTimeout = 0.35f;

        private float _directionChangeRestrictionTimer = 0;

        public EnemyMovementWalkNode(MovementState state) : base(state)
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

            _movementDirection = Mathf.FloorToInt(_owner.transform.localScale.x);
        }

        protected override void UpdateNextState()
        {
            if (_owner.MovementComponent.Velocity.y < 0 &&
                !_owner.RaycastComponent.HasGround)
            {
                NextState = MovementState.Fall;
            }
        }

        protected override void UpdateNodeState()
        {
            if (_owner.GunComponent.IsInUse ||
                _owner.MeleeComponent.IsInUse)
                return;

            _owner.AnimationComponent.SetState(AnimationStates.Run);

            if (!_owner.RaycastComponent.HasBothFeetOnTheGround &&
                _directionChangeRestrictionTimer < 0)
            {
                _movementDirection *= -1;
                _directionChangeRestrictionTimer = _directionChangeTimeout;
            }

            _directionChangeRestrictionTimer -= Time.deltaTime;
            _owner.MovementComponent.SetMovementDirection(_movementDirection);
        }
    }
}
