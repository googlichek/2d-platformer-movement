using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class BulletPool : TickBehaviour
    {
        [SerializeField]
        private RegularBulletPool _regularBulletPool = default;

        [SerializeField]
        private PunchBulletPool _punchBulletPool = default;

        public override void Init()
        {
            base.Init();

            AttachComponent(_regularBulletPool);
            AttachComponent(_punchBulletPool);
        }

        public override void Dispose()
        {
            base.Dispose();

            DetachComponent(_regularBulletPool);
            DetachComponent(_punchBulletPool);
        }

        public Bullet GetBullet(BulletType type)
        {
            Bullet bullet = null;
            switch (type)
            {
                case BulletType.Regular:

                    bullet = _regularBulletPool.Get();
                    return bullet;

                case BulletType.Melee:

                    bullet = _punchBulletPool.Get();
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

                case BulletType.Melee:

                    _punchBulletPool.Release(bullet);
                    break;

                default:
                    break;
            }
        }
    }
}
