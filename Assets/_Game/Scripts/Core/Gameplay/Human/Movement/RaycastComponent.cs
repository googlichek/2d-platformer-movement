using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Core
{
    /// <summary>
    /// Detects proper collisions around collider.
    /// </summary>
    public class RaycastComponent : TickComponent
    {
        [SerializeField] [Space]
        private Transform _raycastLeft = default;

        [SerializeField]
        private Transform _raycastRight = default;

        [SerializeField] [Space]
        private LayerMask _layerMask = LayerMask.GetMask();

        [SerializeField] [Range(0, 16)]
        private float _contactDistanceY = 0.025f;

        private readonly List<RaycastHit2D> _hitsDownLeft = new List<RaycastHit2D>();
        private readonly List<RaycastHit2D> _hitsDownRight = new List<RaycastHit2D>();

        private ContactFilter2D _filter2D;

        private bool _hasGround = false;

        public bool HasGround => _hasGround;

        public override void Init()
        {
            _filter2D.useLayerMask = true;
            _filter2D.layerMask = _layerMask;
        }

        public override void PhysicsTick()
        {
            CastRays(_hitsDownLeft, _raycastLeft.position, Vector2.down, _contactDistanceY);
            CastRays(_hitsDownRight, _raycastRight.position, Vector2.down, _contactDistanceY);

            UpdateGroundState();
        }

        private void CastRays(List<RaycastHit2D> hitList, Vector2 rayOrigin, Vector2 direction, float contactDistance)
        {
            Physics2D.Raycast(rayOrigin, direction, _filter2D, hitList, contactDistance);
        }

        private void UpdateGroundState()
        {
            _hasGround = _hitsDownLeft.Count > 0 || _hitsDownRight.Count > 0;
        }
    }
}
