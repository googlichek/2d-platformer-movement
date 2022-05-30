using UnityEngine;

namespace Game.Scripts.Core
{
    public class PunchBulletPool : BasePool<Bullet>
    {
        [SerializeField]
        private Bullet _punchBulletPrefab = default;

        public override void Init()
        {
            base.Init();

            InitPool(_punchBulletPrefab, transform, 100, 1000);
        }

        public override void Dispose()
        {
            base.Dispose();

            DisposePool();
        }
    }
}
