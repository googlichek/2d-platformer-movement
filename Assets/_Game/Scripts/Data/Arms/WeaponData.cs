using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "SciptableObjects/Data/Human/Weapon")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField]
        private GameObject _bulletPrefab = default;

        [SerializeField] [Range(0, 5000)]
        private float _bulletSpeed = 0;

        [SerializeField] [Range(0, 5)]
        private float shotTimeout = 0;

        public GameObject BulletPrefab => _bulletPrefab;

        public float BulletSpeed => _bulletSpeed;

        public float ShotTimeout => shotTimeout;
    }
}