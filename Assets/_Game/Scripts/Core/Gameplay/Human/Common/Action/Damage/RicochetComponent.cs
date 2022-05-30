using Game.Scripts.Data;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class RicochetComponent : TickComponent 
    {
        [SerializeField]
        private RicochetData _data = default;

        [SerializeField] [Space]
        private Rigidbody2D _body = default;

        private Bullet _bullet = default;

        private bool _canRicochet = false;

        void OnCollisionEnter2D(Collision2D bump)
        {
            if (!_canRicochet)
                return;

            if (_data.LayerMask.HasLayer(bump.gameObject.layer))
            {
                var direction = (bump.gameObject.transform.position - transform.position).normalized;

                var ricochetDirection = (Vector2.up - new Vector2(direction.x, 0)).Normalized();
                _body.velocity = ricochetDirection * _data.RicochetSpeed;

                _body.gravityScale = 1;
                gameObject.layer = (int) Layers.ProjectileShard;

                _canRicochet = false;
            }
            else
            {
                _bullet.Release();
            }
        }

        public void Setup(Bullet bullet)
        {
            _bullet = bullet;
        }

        public override void Enable()
        {
            _body.gravityScale = 0;
            gameObject.layer = (int) Layers.Projectile;

            _canRicochet = true;
        }
    }
}
