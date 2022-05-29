using UnityEngine;

namespace Game.Scripts.Core
{
    public class HumanController : TickBehaviour
    {
        [SerializeField]
        protected RaycastComponent raycastComponent = default;

        [SerializeField]
        protected MovementComponent movementComponent = default;

        [SerializeField]
        protected BaseStateMachineComponent<MovementState> movementStateMachineComponent = default;

        [SerializeField]
        protected AnimationComponent animationComponent = default;

        [SerializeField]
        protected SpriteFlipComponent spriteFlipComponent = default;

        public RaycastComponent RaycastComponent => raycastComponent;

        public MovementComponent MovementComponent => movementComponent;

        public BaseStateMachineComponent<MovementState> MovementStateMachineComponent =>
            movementStateMachineComponent;

        public AnimationComponent AnimationComponent => animationComponent;

        public SpriteFlipComponent SpriteFlipComponent => spriteFlipComponent;

        public override void Init()
        {
            base.Init();

            AttachComponent(raycastComponent);
            AttachComponent(movementComponent);
            AttachComponent(movementStateMachineComponent);
            AttachComponent(animationComponent);
            AttachComponent(spriteFlipComponent);
        }

        public override void Dispose()
        {
            base.Dispose();

            DetachComponent(raycastComponent);
            DetachComponent(movementComponent);
            DetachComponent(movementStateMachineComponent);
            DetachComponent(animationComponent);
            DetachComponent(spriteFlipComponent);
        }
    }
}