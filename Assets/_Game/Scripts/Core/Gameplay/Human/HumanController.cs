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
        protected BaseStateMachineComponent<ActionState> actionStateMachineComponent = default;

        [SerializeField]
        protected AnimationComponent animationComponent = default;

        [SerializeField]
        protected SpriteFlipComponent spriteFlipComponent = default;

        [SerializeField]
        protected GunComponent gunComponent = default;

        [SerializeField]
        protected ParticlesComponent dustParticlesComponent = default;

        public RaycastComponent RaycastComponent => raycastComponent;

        public MovementComponent MovementComponent => movementComponent;

        public BaseStateMachineComponent<MovementState> MovementStateMachineComponent =>
            movementStateMachineComponent;

        public BaseStateMachineComponent<ActionState> ActionStateMachineComponent =>
            actionStateMachineComponent;

        public AnimationComponent AnimationComponent => animationComponent;

        public SpriteFlipComponent SpriteFlipComponent => spriteFlipComponent;

        public GunComponent GunComponent => gunComponent;

        public ParticlesComponent DustParticlesComponent => dustParticlesComponent;

        public override void Init()
        {
            base.Init();

            AttachComponent(raycastComponent);
            AttachComponent(movementComponent);
            AttachComponent(movementStateMachineComponent);
            AttachComponent(actionStateMachineComponent);
            AttachComponent(animationComponent);
            AttachComponent(spriteFlipComponent);
            AttachComponent(gunComponent);
            AttachComponent(dustParticlesComponent);
        }

        public override void Dispose()
        {
            base.Dispose();

            DetachComponent(raycastComponent);
            DetachComponent(movementComponent);
            DetachComponent(movementStateMachineComponent);
            DetachComponent(actionStateMachineComponent);
            DetachComponent(animationComponent);
            DetachComponent(spriteFlipComponent);
            DetachComponent(gunComponent);
            DetachComponent(dustParticlesComponent);
        }
    }
}