using Game.Scripts.Core;
using Zenject;

namespace Icebreaker.Scripts.Core
{
    public class BulletPoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<BulletPool>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}
