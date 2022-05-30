using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "RicochetData", menuName = "ScriptableObject/Data/Ricochet")]
    public class RicochetData : ScriptableObject
    {
        [SerializeField]
        private LayerMask _layerMask = LayerMask.GetMask();

        [SerializeField] [Range(0, 500)] [Space]
        private float _ricochetSpeed = 0;

        public LayerMask LayerMask => _layerMask;

        public float RicochetSpeed => _ricochetSpeed;
    }
}