namespace Game.Scripts.Core
{
    public class PlayerController : HumanController
    {
        public override void Init()
        {
            base.Init();

            var inputDrivenMovementStateMachine =
                (InputDrivenMovementStateMachineComponent) movementStateMachineComponent;
            inputDrivenMovementStateMachine.Setup(this);

            var inputDrivenActionStateMachine =
                (InputDrivenActionStateMachineComponent) actionStateMachineComponent;
            inputDrivenActionStateMachine.Setup(this);
        }
    }
}
