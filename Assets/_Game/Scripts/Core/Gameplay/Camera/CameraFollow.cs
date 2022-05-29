using Game.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class CameraFollow : TickComponent
    {
        [SerializeField] [Range(-100, 100)]
        private float _offsetFromCenterY = 0;

        [Space]

        [SerializeField] [Range(-100, 100)]
        private float _cameraOffsetX = 0;

        [SerializeField] [Range(-100, 100)]
        private float _cameraOffsetY = 0;

        [Space]

        [SerializeField] [Range(0, 10)]
        private float _smoothingTimeX = 0;

        [SerializeField] [Range(0, 10)]
        private float _smoothingTimeY = 0;

        private SignalBus _signalBus = default;

        private Vector2 _delta = Vector2.zero;
        private Vector2 _velocity = Vector2.zero;

        private Vector2 _position = Vector2.zero;

        private PlayerController _playerController = default;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public override void Enable()
        {
            _signalBus.Subscribe<Signals.HumanSpawnedSignal>(x => TryToGetPlayer(x.Human));
        }

        public override void Disable()
        {
            _signalBus.TryUnsubscribe<Signals.HumanSpawnedSignal>(x => TryToGetPlayer(x.Human));
        }

        public override void CameraTick()
        {
            UpdatePosition();
        }

        private void TryToGetPlayer(GameObject human)
        {
            if (_playerController != null)
                return;

            var playerController = human.GetComponent<PlayerController>();
            if (playerController == null)
                return;

            _playerController = playerController;
        }

        private void UpdatePosition()
        {
            if (_playerController == null)
                return;

            var signX =
                _playerController.MovementComponent.Velocity.x.IsEqual(0)
                    ? 0
                    : Mathf.Sign(_playerController.MovementComponent.Velocity.x);

            var signY =
                _playerController.MovementComponent.Velocity.y.IsEqual(0)
                    ? 0 :
                    Mathf.Sign(_playerController.MovementComponent.Velocity.y);

            var speedMultiplierX =
                Mathf.Abs(
                    _playerController.MovementComponent.Velocity.x /
                    _playerController.MovementComponent.Data.MaxVelocityX);

            var speedMultiplierY =
                Mathf.Abs(
                    _playerController.MovementComponent.Velocity.y /
                    _playerController.MovementComponent.Data.MaxVelocityY);

            var offsetX = signX * _cameraOffsetX * speedMultiplierX;
            var offsetY = signY * _cameraOffsetY * speedMultiplierY;

            _delta.x = Mathf.SmoothDamp(_delta.x, offsetX, ref _velocity.x, _smoothingTimeX);
            _delta.y = Mathf.SmoothDamp(_delta.y, offsetY, ref _velocity.y, _smoothingTimeY);

            _position.x = (_playerController.transform.position.x + _delta.x);
            _position.y = (_playerController.transform.position.y + _offsetFromCenterY + _delta.y);

            transform.localPosition = _position;
        }
    }
}
