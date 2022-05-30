using System;
using UnityEngine;

namespace Game.Scripts.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "HealthData", menuName = "ScriptableObject/Data/Human/Health")]
    public class HealthData : ScriptableObject
    {
        [SerializeField] [Range(0, 1000)] [Space]
        private float _maxHealth = 0;

        [SerializeField] [Space]
        private LayerMask _layerMask = 0;

        public float MaxHealth => _maxHealth;
        public LayerMask LayerMask => _layerMask;
    }
}
