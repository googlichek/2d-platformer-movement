using System;
using UnityEngine;

namespace Game.Scripts.Data
{
    [Serializable]
    [CreateAssetMenu(fileName = "HitFlashData", menuName = "ScriptableObject/Data/Human/HitFlash")]
    public class HitFlashData : ScriptableObject
    {
        [SerializeField]
        private Color _color = Color.white;

        [SerializeField] [Range(0, 1)] [Space]
        private float _damageFlashAmount = 0;

        [SerializeField] [Range(0, 1)]
        private float _damageFlashDuration = 0;

        public Color Color => _color;

        public float DamageFlashAmount => _damageFlashAmount;
        public float DamageFlashDuration => _damageFlashDuration;
    }
}
