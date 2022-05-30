namespace Game.Scripts.Core
{
    public class EnemyController : HumanController
    {
        public override void Init()
        {
            base.Init();

            var enemyMovementStateMachine =
                (EnemyMovementStateMachineComponent) movementStateMachineComponent;
            enemyMovementStateMachine.Setup(this);

            var enemyActionStateMachine =
                (EnemyActionStateMachineComponent) actionStateMachineComponent;
            enemyActionStateMachine.Setup(this);
        }
    }
}
