using UnityEngine;

namespace Game.Scripts.Core
{
    public class CameraShaker : TickComponent
    {
        [SerializeField] [Range(0, 10)]
        private int _traumaExponent = 2;

        [SerializeField] [Range(0, 1)]
        private float _traumaDecayFactor = 0.8f;

        [SerializeField] [Range(0, 10)] [Space]
        private float _maximumOffsetTranslational = 2;

        [SerializeField] [Range(0, 90)]
        private float _maximumOffsetRotational = 10;

        [SerializeField] [Range(0, 60)] [Space]
        private int _shakeFrequency = 45;

        [SerializeField] [Range(0, 1)] [Space]
        private float _maximumTrauma = 0.6f;

        [SerializeField] [Range(0, 1)]
        private float _minimumTrauma = 0f;

        [SerializeField] [Range(0, 1)] [Space]  
        private float _movementTrauma = 0.4f;

        [SerializeField] [Range(0, 1)]
        private float _damageTrauma = 0.2f;

        private float _seed = -1;

        private float _frequency = -1;
        private float _trauma = -1;

        private Vector3 _shakeOffset = Vector3.zero;

        public float MovementTrauma => _movementTrauma;
        public float DamageTrauma => _damageTrauma;

        public override void Enable()
        {
            _seed = Random.value;
        }

        public override void Tick()
        {
            _frequency = _shakeFrequency * Time.timeScale;
            _trauma = Mathf.Clamp01(_trauma - Time.deltaTime * _traumaDecayFactor);
        }

        public override void CameraTick()
        {
            var shakeFactor = Mathf.Pow(_trauma, _traumaExponent);

            var x = shakeFactor * _maximumOffsetTranslational * (2 * Mathf.PerlinNoise(_seed, Time.time * _frequency) - 1);
            var y = shakeFactor * _maximumOffsetTranslational * (2 * Mathf.PerlinNoise(_seed + 1, Time.time * _frequency) - 1);
            var z = shakeFactor * _maximumOffsetRotational * (2 * Mathf.PerlinNoise(_seed + 2, Time.time * _frequency) - 1);

            _shakeOffset.x = x;
            _shakeOffset.y = y;
            _shakeOffset.z = 0;

            transform.localPosition += _shakeOffset;
            transform.localRotation = Quaternion.Euler(0, 0, z);
        }

        public void AddTrauma(float value)
        {
            _trauma = Mathf.Clamp(_trauma + Mathf.Abs(value), _minimumTrauma, _maximumTrauma);
        }
    }
}