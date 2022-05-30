using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class HitFlashComponent : TickComponent
    {
        [SerializeField]
        private HitFlashData _data = default;

        [SerializeField] [Space]
        private SpriteRenderer _spriteRenderer = default;

        private static readonly int FlashColor = Shader.PropertyToID(FlashColorParameterName);
        private static readonly int FlashAmount = Shader.PropertyToID(FlashAmoutParameterName);

        private const string FlashColorParameterName = "_FlashColor";
        private const string FlashAmoutParameterName = "_FlashAmount";

        private float _flashAmount = 0;
        private float _flashVelocity = 0;

        private MaterialPropertyBlock _materialPropertyBlock = default;

        public override void Init()
        {
            _materialPropertyBlock = new MaterialPropertyBlock();
            _spriteRenderer.GetPropertyBlock(_materialPropertyBlock);
        }

        public override void Enable()
        {
            _materialPropertyBlock.SetFloat(FlashAmount, 0);
            _spriteRenderer.SetPropertyBlock(_materialPropertyBlock);
        }

        public override void Tick()
        {
            _flashAmount = Mathf.SmoothDamp(_flashAmount, 0, ref _flashVelocity, _data.DamageFlashDuration);

            _materialPropertyBlock.SetFloat(FlashAmount, _flashAmount);
            _spriteRenderer.SetPropertyBlock(_materialPropertyBlock);
        }

        public void StartDamageFlash()
        {
            _materialPropertyBlock.SetColor(FlashColor, _data.Color);
            _materialPropertyBlock.SetFloat(FlashAmount, _data.DamageFlashAmount);
            _spriteRenderer.SetPropertyBlock(_materialPropertyBlock);

            _flashAmount = _data.DamageFlashAmount;
        }
    }
}
