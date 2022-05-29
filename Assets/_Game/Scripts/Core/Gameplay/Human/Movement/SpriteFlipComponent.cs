using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class SpriteFlipComponent : TickComponent
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer = default;

        [SerializeField]
        private MovementComponent _movementComponent = default;

        private float _lastMovementDirection = 0;

        public override void Tick()
        {
            UpdateState();
        }

        public void UpdateState()
        {
            if (!_movementComponent.MovementDirection.IsEqual(0))
                _lastMovementDirection = _movementComponent.MovementDirection;
            else
            {
                _lastMovementDirection = 0;
            }

            if (_lastMovementDirection.IsEqual(0))
                return;

            _spriteRenderer.flipX = _lastMovementDirection < 0;
        }
    }
}
