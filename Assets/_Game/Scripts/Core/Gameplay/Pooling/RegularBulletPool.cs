using UnityEngine;

namespace Game.Scripts.Core
{
    public class RegularBulletPool : BasePool<Bullet>
    {
        [SerializeField]
        private Bullet _regularBulletPrefab = default;

        public override void Init()
        {
            base.Init();

            InitPool(_regularBulletPrefab, transform, 100, 1000);
        }

        public override void Dispose()
        {
            base.Dispose();

            DisposePool();
        }
    }
}
