using Game.Scripts.Core;
using Zenject;

namespace Icebreaker.Scripts.Core
{
    public class SignalBusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Zenject.SignalBusInstaller.Install(Container);

            Container.DeclareSignal<Signals.HumanSpawnedSignal>();
        }
    }
}
