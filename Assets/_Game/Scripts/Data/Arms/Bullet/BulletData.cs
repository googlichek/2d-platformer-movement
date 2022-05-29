using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "SciptableObjects/Data/Weapon/Bullet")]
    public class BulletData : ScriptableObject
    {
        [SerializeField]
        private BulletType _type = BulletType.None;

        [SerializeField]
        [Range(0, 5000)]
        private float _speed = 0;

        [SerializeField]
        [Range(0, 100)]
        private float _damageAmount = 0;

        [SerializeField]
        [Range(0, 5)]
        private float _lifeTime = 0;

        public BulletType Type => _type;

        public float Speed => _speed;

        public float DamageAmount => _damageAmount;

        public float LifeTime => _lifeTime;
    }
}