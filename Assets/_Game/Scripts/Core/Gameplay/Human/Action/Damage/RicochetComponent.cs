using Game.Scripts.Data;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class RicochetComponent : TickComponent 
    {
        [SerializeField]
        private BulletData _data = default;

        [SerializeField] [Space]
        private Rigidbody2D _body = default;

        [SerializeField] [Space]
        private LayerMask _layerMask = LayerMask.GetMask();

        private bool _canRicochet = false;

        void OnCollisionEnter2D(Collision2D bump)
        {
            if (!_canRicochet)
                return;

            if (!_layerMask.HasLayer(bump.gameObject.layer))
                return;

            var direction = (bump.gameObject.transform.position - transform.position).normalized;

            var ricochetDirection = (Vector2.up - new Vector2(direction.x, 0)).Normalized();
            _body.velocity = ricochetDirection * _data.RicochetSpeed;

            _body.gravityScale = 1;
            gameObject.layer = (int) Layers.ProjectileShard;

            _canRicochet = false;
        }

        public override void Enable()
        {
            _body.gravityScale = 0;
            gameObject.layer = (int) Layers.Projectile;

            _canRicochet = true;
        }
    }
}
