using UnityEngine;

namespace Game.Scripts.Core
{
    public class AnimationComponent : TickComponent
    {
        [SerializeField]
        private Animator _animator = default;

        private string _currentAnimation = string.Empty;

        public Animator Animator => _animator;

        public void SetState(string stateName)
        {
            if (_currentAnimation == stateName &&
                CheckIfAnimationIsPlaying(stateName))
                return;

            _animator.Play(stateName);
            _currentAnimation = stateName;
        }

        public float GetCurrentAnimationLength()
        {
            return
                CheckIfAnimationIsPlaying(_currentAnimation)
                    ? _animator.GetCurrentAnimatorStateInfo(0).length
                    : 0;
        }

        private bool CheckIfAnimationIsPlaying(string stateName)
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                   _animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f;
        }
    }
}
