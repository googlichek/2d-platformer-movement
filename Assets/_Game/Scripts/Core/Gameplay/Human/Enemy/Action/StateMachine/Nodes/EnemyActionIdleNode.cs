namespace Game.Scripts.Core
{
    public class EnemyActionIdleNode : BaseEntityNode<ActionState>
    {
        private HumanController _owner = default;

        public EnemyActionIdleNode(ActionState state) : base(state)
        {
        }

        public void Setup(HumanController owner)
        {
            _owner = owner;
        }

        protected override void UpdateNextState()
        {
        }

        protected override void UpdateNodeState()
        {
        }
    }
}
