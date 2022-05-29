using System;
using Game.Scripts.Utils;

namespace Game.Scripts.Core
{
    public abstract class BaseEntityNode<TState> : IStateMachineNode<TState>
        where TState : struct, Enum
    {
        protected readonly TState NodeState;

        protected TState EnterState;
        protected TState NextState;
        protected TState ExitState;

        protected BaseEntityNode(TState state)
        {
            NodeState = state;
        }

        public virtual void Enter(TState from)
        {
            EnterState = from;
            NextState = NodeState;
        }

        public virtual void Tick()
        {
            if (StaticMethods.EnumEquals(NextState, NodeState))
                UpdateNodeState();

            UpdateNextState();
        }

        public virtual void Exit(TState to)
        {
            ExitState = to;
        }

        public virtual TState GetNextState()
        {
            return NextState;
        }

        protected abstract void UpdateNextState();

        protected abstract void UpdateNodeState();
    }
}
