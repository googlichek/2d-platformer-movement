using Game.Scripts.Core;
using Zenject;

namespace Icebreaker.Scripts.Core
{
    public class CameraOperatorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CameraOperator>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}
