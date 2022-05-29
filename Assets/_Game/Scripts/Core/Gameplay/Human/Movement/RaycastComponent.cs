using System.Collections.Generic;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    /// <summary>
    /// Detects proper collisions around collider.
    /// </summary>
    public class RaycastComponent : TickComponent
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D = default;

        [SerializeField] [Space]
        private LayerMask _layerMask = LayerMask.GetMask();

        [SerializeField] [Range(0, 16)] [Space]
        private float _contactDistanceX = 0.025f;

        [SerializeField] [Range(0, 16)]
        private float _contactDistanceY = 0.025f;

        private readonly List<RaycastHit2D> _hitsDown = new List<RaycastHit2D>();

        private ContactFilter2D _filter2D;

        private bool _hasGround = false;

        public bool HasGround => _hasGround;

        void OnCollisionEnter2D(Collision2D bump)
        {
            if (!_layerMask.HasLayer(bump.gameObject.layer))
                return;

            CastRays(_hitsDown, Vector2.down, _contactDistanceY);
        }

        void OnCollisionExit2D(Collision2D bump)
        {
            if (!_layerMask.HasLayer(bump.gameObject.layer))
                return;

            CastRays(_hitsDown, Vector2.down, _contactDistanceY);
            _hasGround = _hitsDown.Count > 0;
        }

        public override void Init()
        {
            _filter2D.useLayerMask = true;
            _filter2D.layerMask = _layerMask;
        }

        public override void PhysicsTick()
        {
            CastRays(_hitsDown, Vector2.down, _contactDistanceY);
            _hasGround = _hitsDown.Count > 0;
        }

        private void CastRays(List<RaycastHit2D> hitList, Vector2 direction, float contactDistance)
        {
            _rigidbody2D.Cast(direction, _filter2D, hitList, contactDistance);
        }
    }
}
