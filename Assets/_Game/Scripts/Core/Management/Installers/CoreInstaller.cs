using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _gameManager = default;

        public override void InstallBindings()
        {
            Container
                .Bind<GameManager>()
                .FromComponentInNewPrefab(_gameManager)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<InputWrapper>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

        }
    }
}
