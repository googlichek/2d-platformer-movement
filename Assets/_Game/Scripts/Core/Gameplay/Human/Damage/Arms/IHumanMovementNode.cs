namespace Game.Scripts.Core
{
    public interface IHumanMovementNode
    {
        void Setup(HumanController owner, InputWrapper InputWrapper, CameraOperator cameraOperator);
    }
}
