using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class BulletPool : TickBehaviour
    {
        [SerializeField]
        private RegularBulletPool _regularBulletPool = default;

        public override void Init()
        {
            base.Init();

            AttachComponent(_regularBulletPool);
        }

        public override void Dispose()
        {
            base.Dispose();

            DetachComponent(_regularBulletPool);
        }

        public Bullet GetBullet(BulletType type)
        {
            switch (type)
            {
                case BulletType.Regular:

                    var bullet = _regularBulletPool.Get();
                    return bullet;

                default:
                    return null;
            }
        }

        public void ReleaseBullet(Bullet bullet)
        {
            switch (bullet.Type)
            {
                case BulletType.Regular:

                    _regularBulletPool.Release(bullet);
                    break;

                default:
                    break;
            }
        }
    }
}
