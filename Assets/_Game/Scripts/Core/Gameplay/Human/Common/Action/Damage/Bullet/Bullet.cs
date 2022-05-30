using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class Bullet : TickBehaviour, IBullet
    {
        [SerializeField]
        private BulletData _data = default;

        [SerializeField] [Space]
        private Rigidbody2D _body = default;

        [SerializeField] [Space]
        private RicochetComponent _ricochetComponent = default;

        private BulletPool _bulletPool = default;

        public BulletType Type => _data.Type;

        public BulletData Data => _data;

        public Rigidbody2D Body => _body;

        public int OwnerId => _ownerId;

        public float DamageAmount => _data.DamageAmount;

        private int _ownerId = 0;

        private float _creationTime = 0;

        private bool _isActive = false;

        public void Setup(BulletPool bulletPool, int ownerId)
        {
            _bulletPool = bulletPool;
            _ownerId = ownerId;
        }

        public override void Init()
        {
            base.Init();

            AttachComponent(_ricochetComponent);
            _ricochetComponent.Setup(this);
        }

        public override void Enable()
        {
            base.Enable();

            _creationTime = Time.time;
            _isActive = true;
        }

        public override void Tick()
        {
            base.Tick();

            if (_creationTime + _data.LifeTime > Time.time)
                return;

            if (_isActive)
                Release();
        }

        public override void Dispose()
        {
            base.Dispose();

            DetachComponent(_ricochetComponent);
        }

        public void Release()
        {
            _isActive = false;
            _bulletPool.ReleaseBullet(this);
        }
    }
}
