using Game.Scripts.Utils;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts.Core
{
    public class SpriteFlipComponent : TickComponent
    {
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

            var sign = Mathf.Sign(_lastMovementDirection);

            transform.localScale = new Vector3(sign, 1, 1);
        }
    }
}
