using System.Collections.Generic;
using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Core
{
    /// <summary>
    /// Detects proper collisions around collider.
    /// </summary>
    public class RaycastComponent : TickComponent
    {
        [SerializeField]
        private RaycastData _data = default;

        [SerializeField] [Space]
        private Transform _raycastLeft = default;

        [SerializeField]
        private Transform _raycastRight = default;

        private readonly List<RaycastHit2D> _hitsDownLeft = new();
        private readonly List<RaycastHit2D> _hitsDownRight = new();

        private ContactFilter2D _filter2D;

        private bool _hasGround = false;

        public bool HasGround => _hasGround;

        public override void Init()
        {
            _filter2D.useLayerMask = true;
            _filter2D.layerMask = _data.LayerMask;
        }

        public override void PhysicsTick()
        {
            CastRays(_hitsDownLeft, _raycastLeft.position, Vector2.down, _data.ContactDistanceY);
            CastRays(_hitsDownRight, _raycastRight.position, Vector2.down, _data.ContactDistanceY);

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
