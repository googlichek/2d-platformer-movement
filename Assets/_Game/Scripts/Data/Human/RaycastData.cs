using System;
using UnityEngine;

namespace Game.Scripts.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "RaycastData", menuName = "ScriptableObject/Data/Human/Raycast")]
    public class RaycastData : ScriptableObject
    {
        [SerializeField] [Range(0, 16)]
        private float _contactDistanceY = 0.025f;

        [SerializeField] [Space]
        private LayerMask _layerMask = LayerMask.GetMask();

        public float ContactDistanceY => _contactDistanceY;

        public LayerMask LayerMask => _layerMask;
    }
}
