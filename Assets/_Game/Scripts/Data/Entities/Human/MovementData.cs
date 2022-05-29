using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "MovementData", menuName = "SciptableObjects/Data/Human/Movement")]
    public class MovementData : ScriptableObject
    {
        [SerializeField] [Range(0, 10000)]
        private float _maxVelocityX = 0;

        [SerializeField] [Range(0, 10000)]
        private float _maxVelocityY = 0;

        [Space] [SerializeField] [Range(0, 10000)]
        private float _walkSpeed = 0;

        [SerializeField] [Range(0, 10000)]
        private float _crouchSpeed = 0;

        [Space] [SerializeField] [Range(0, 10000)]
        private float _defaultGroundVelocityY = 0;

        [SerializeField] [Range(0, 10000)]
        private float _slopeVelocityY = 0;

        [Space] [SerializeField] [Range(0, 100)]
        private float _timeToJumpApex = 0;

        [Space] [SerializeField] [Range(0, 1000)]
        private float _maxJumpHeight = 0;

        [SerializeField] [Range(0, 1000)]
        private float _minJumpHeight = 0;

        [Space] [SerializeField] [Range(0, 1000)]
        private float dashDistance = 0;

        [SerializeField] [Range(0, 1)]
        private float dashDuration = 0;

        [Space] [SerializeField] [Range(0, 5)]
        private int _maxConsecutiveJumps = 0;

        [Space] [SerializeField] [Range(0, 10)]
        private float _accelerationTimeGrounded = 0;

        [SerializeField] [Range(0, 10)]
        private float _accelerationTimeAirborne = 0;

        [SerializeField] [Range(0, 10)]
        private float _accelerationTimeDash = 0;

        public float MaxVelocityX => _maxVelocityX;
        public float MaxVelocityY => _maxVelocityY;

        public float WalkSpeed => _walkSpeed;
        public float CrouchSpeed => _crouchSpeed;

        public float DefaultGroundVelocityY => _defaultGroundVelocityY;
        public float SlopeVelocityY => _slopeVelocityY;

        public float TimeToJumpApex => _timeToJumpApex;

        public float MaxJumpHeight => _maxJumpHeight;
        public float MinJumpHeight => _minJumpHeight;

        public float DashDistance => dashDistance;
        public float DashDuration => dashDuration;

        public int MaxConsecutiveJumps => _maxConsecutiveJumps;

        public float AccelerationTimeGrounded => _accelerationTimeGrounded;
        public float AccelerationTimeAirborne => _accelerationTimeAirborne;
        public float AccelerationTimeDash => _accelerationTimeDash;
    }
}