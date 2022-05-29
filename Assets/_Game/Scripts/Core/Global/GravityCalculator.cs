using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class GravityCalculator : TickBehaviour
    {
        [SerializeField]
        private MovementData _data = default;

        private Vector3 _gravity = default;

        public override void Init()
        {
            base.Init();

            RecalculateGravity(_data);
        }

        private void RecalculateGravity(MovementData data)
        {
            _gravity = Vector2.zero;
            _gravity.y = -2 * data.MaxJumpHeight / Mathf.Pow(data.TimeToJumpApex, 2);

            Physics2D.gravity = _gravity;
        }
    }
}
