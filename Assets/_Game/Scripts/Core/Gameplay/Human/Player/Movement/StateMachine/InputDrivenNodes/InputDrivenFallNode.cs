﻿namespace Game.Scripts.Core
{
    public class InputDrivenFallNode : BaseEntityNode<MovementState>
    {
        private HumanController _owner = default;
        private InputWrapper _inputWrapper = default;
        private CameraOperator _cameraOperator = default;

        public InputDrivenFallNode(MovementState state) : base(state)
        {
        }

        public void Setup(HumanController owner, InputWrapper inputWrapper, CameraOperator cameraOperator)
        {
            _owner = owner;
            _inputWrapper = inputWrapper;
            _cameraOperator = cameraOperator;
        }

        protected override void UpdateNextState()
        {
            if (_owner.RaycastComponent.HasGround)
            {
                NextState = MovementState.Walk;
            }

            if (_inputWrapper.IsJumpPressed &&
                !_owner.MovementComponent.AreConsecutiveJumpsDepleted)
            {
                NextState = MovementState.Jump;
            }
        }

        protected override void UpdateNodeState()
        {
            _owner.MovementComponent.SetMovementDirection(_inputWrapper.Horizontal);
            _owner.AnimationComponent.SetState(AnimationStates.Fall);
        }
    }
}
