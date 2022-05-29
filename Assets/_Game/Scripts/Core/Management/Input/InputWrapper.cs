using Rewired;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class InputWrapper : TickBehaviour
    {
        [SerializeField]
        private GameObject _rewiredInputManagerTemplate = default;

        private Player _player;

        private int _playerId = 0;

        private float _horizontal = 0;
        private float _vertical = 0;

        private float _lookX = 0;
        private float _lookY = 0;

        private bool _isJumpPressed = false;
        private bool _isJumpReleased = false;
        private bool _isJumpHeld = false;
        
        private bool _isDashPressed = false;
        private bool _isDashReleased = false;
        private bool _isDashHeld = false;

        private bool _isCrouchPressed = false;
        private bool _isCrouchReleased = false;
        private bool _isCrouchHeld = false;

        private bool _isWeaponUsePressed = false;
        private bool _isWeaponUseReleased = false;
        private bool _isWeaponUseHeld = false;

        public float Horizontal => _horizontal;
        public float Vertical => _vertical;

        public float LookX => _lookX;
        public float LookY => _lookY;

        public bool IsJumpPressed => _isJumpPressed;
        public bool IsJumpReleased => _isJumpReleased;
        public bool IsJumpHeld => _isJumpHeld;
        
        public bool IsDashPressed => _isDashPressed;
        public bool IsDashReleased => _isDashReleased;
        public bool IsDashHeld => _isDashHeld;

        public bool IsCrouchPressed => _isCrouchPressed;
        public bool IsCrouchReleased => _isCrouchReleased;
        public bool IsCrouchHeld => _isCrouchHeld;
        
        public bool IsWeaponUsePressed => _isWeaponUsePressed;
        public bool IsWeaponUseReleased => _isWeaponUseReleased;
        public bool IsWeaponUseHeld => _isWeaponUseHeld;

        public override void Init()
        {
            priority = TickPriority.High;

            Instantiate(_rewiredInputManagerTemplate, transform.parent);

            _player = ReInput.players.GetPlayer(_playerId);
        }

        public override void Tick()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            _horizontal = _player.GetAxis(InputActions.Horizontal);
            _vertical = _player.GetAxis(InputActions.Vertical);

            _lookX = _player.GetAxis(InputActions.LookX);
            _lookY = _player.GetAxis(InputActions.LookY);

            _isJumpPressed = _player.GetButtonDown(InputActions.Jump);
            _isJumpReleased = _player.GetButtonUp(InputActions.Jump);
            _isJumpHeld = _player.GetButton(InputActions.Jump);

            _isDashPressed = _player.GetButtonDown(InputActions.Dash);
            _isDashReleased = _player.GetButtonUp(InputActions.Dash);
            _isDashHeld = _player.GetButton(InputActions.Dash);
            
            _isCrouchPressed = _player.GetButtonDown(InputActions.Crouch);
            _isCrouchReleased = _player.GetButtonUp(InputActions.Crouch);
            _isCrouchHeld = _player.GetButton(InputActions.Crouch);

            _isWeaponUsePressed = _player.GetButtonDown(InputActions.WeaponUse);
            _isWeaponUseReleased = _player.GetButtonUp(InputActions.WeaponUse);
            _isWeaponUseHeld = _player.GetButton(InputActions.WeaponUse);
        }
    }
}
