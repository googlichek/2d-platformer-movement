using System;
using System.Collections.Generic;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class BaseStateMachineComponent<TState> : TickComponent
        where TState : struct, Enum
    {
        protected readonly Dictionary<TState, IStateMachineNode<TState>> nodes = new();

        protected IStateMachineNode<TState> currentNode = default;
        protected TState currentState = default;

        public TState ActiveState => currentState;

        public override void Enable()
        {
            ResetState();
        }

        public override void Tick()
        {
            UpdateState(currentNode.GetNextState());
            currentNode.Tick();
        }

        protected virtual void ResetState()
        {
            currentNode = nodes[currentState];
            currentNode.Enter(currentState);
        }

        protected void UpdateState(TState nextState)
        {
            //Debug.Log($"STATE: {nextState}");
            if (StaticMethods.EnumEquals(currentState, nextState))
                return;

            var existsInNodes = nodes.TryGetValue(nextState, out var nextNode);
            if (!existsInNodes)
            {
                Debug.LogError($"Trying to transition to nonexistent state node: {nextState}");
                return;
            }

            currentNode.Exit(nextState);
            currentNode = nextNode;

            currentNode.Enter(currentState);
            currentState = nextState;
        }

        protected TNode CreateNode<TNode>(TState state) where TNode : BaseEntityNode<TState>
        {
            var node = (TNode)Activator.CreateInstance(typeof(TNode), state);
            nodes.Add(state, node);

            return node;
        }
    }
}
