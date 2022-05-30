using Game.Scripts.Data;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class HealthComponent : TickComponent
    {
        [SerializeField]
        private HealthData _data = default;

        [SerializeField] [Space]
        private HitFlashComponent _hitFlashComponent = default;

        private float _health = 0;

        private void OnEnable()
        {
            _health = _data.MaxHealth;
        }

        void OnCollisionEnter2D(Collision2D bump)
        {
            if (!_data.LayerMask.HasLayer(bump.gameObject.layer))
                return;

            var bullet = bump.gameObject.GetComponent<IBullet>();
            if (bullet == null || bullet.OwnerId == Id)
                return;

            _hitFlashComponent.StartDamageFlash();
            _health = Mathf.Clamp(_health - bullet.DamageAmount, 0, _data.MaxHealth);
        }
    }
}
