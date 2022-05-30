using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObject/Data/Bullet")]
    public class BulletData : ScriptableObject
    {
        [SerializeField]
        private BulletType _type = BulletType.None;

        [SerializeField] [Range(0, 5000)] [Space]
        private float _speed = 0;

        [SerializeField] [Range(0, 500)]
        private float _ricochetSpeed = 0;

        [SerializeField]
        [Range(0, 100)]
        private float _damageAmount = 0;

        [SerializeField]
        [Range(0, 5)]
        private float _lifeTime = 0;

        public BulletType Type => _type;

        public float Speed => _speed;

        public float RicochetSpeed => _ricochetSpeed;

        public float DamageAmount => _damageAmount;

        public float LifeTime => _lifeTime;
    }
}