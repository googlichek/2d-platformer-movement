using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class HumanSpawner : TickBehaviour
    {
        [SerializeField]
        private GameObject _prefab = default;

        [SerializeField] [Space]
        private Transform _spawnRoot = default;

        [SerializeField] [Space]
        private Color _gizmoColor = Color.white;

        private DiContainer _diContainer = default;
        private SignalBus _signalBus = default;

        private bool _hasSpawned = false;

        [Inject]
        public void Construct(DiContainer diContainer, SignalBus signalBus)
        {
            _diContainer = diContainer;
            _signalBus = signalBus;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawCube(transform.localPosition, Vector3.one);
        }

        public override void Tick()
        {
            base.Tick();

            if (_hasSpawned)
                return;

            _hasSpawned = true;

            var human =
                _diContainer.InstantiatePrefab(_prefab, _spawnRoot);

            human.transform.localScale = Vector3.one;
            human.transform.SetPositionAndRotation(transform.localPosition, transform.localRotation);

            _signalBus.TryFire(new Signals.HumanSpawnedSignal(human));
        }
    }
}
