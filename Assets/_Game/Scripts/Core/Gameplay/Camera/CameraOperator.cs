using UnityEngine;

namespace Game.Scripts.Core
{
    public class CameraOperator : TickBehaviour
    {
        [SerializeField]
        private Camera _camera = default;

        [SerializeField]
        private CameraFollow _follow = default;

        [SerializeField]
        private CameraShaker _shaker = default;

        public Camera Camera => _camera;
        public CameraFollow Follow => _follow;
        public CameraShaker Shaker => _shaker;

        public override void Init()
        {
            base.Init();

            AttachComponent(_follow);
            AttachComponent(_shaker);

            _camera.transform.localPosition = new(0, 0, -10);
        }

        public override void Dispose()
        {
            DetachComponent(_follow);
            DetachComponent(_shaker);

            base.Dispose();
        }
    }
}
