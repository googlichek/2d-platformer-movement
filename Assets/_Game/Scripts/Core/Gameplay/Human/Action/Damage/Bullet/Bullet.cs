using Game.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class Bullet : TickBehaviour, IBullet
    {
        [SerializeField]
        private BulletData _data = default;

        [SerializeField]
        private Rigidbody2D _body = default;

        private BulletPool _bulletPool = default;

        public BulletType Type => _data.Type;

        public BulletData Data => _data;

        public Rigidbody2D Body => _body;

        public int OwnerId => id;

        public float DamageAmount => _data.DamageAmount;

        private float _creationTime = 0;

        public void Setup(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public override void Enable()
        {
            base.Enable();

            _creationTime = Time.time;
        }

        public override void Tick()
        {
            base.Tick();

            if (_creationTime + _data.LifeTime > Time.time)
                return;

            _bulletPool.ReleaseBullet(this);
        }
    }
}
