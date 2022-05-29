using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "SciptableObjects/Data/Weapon/Gun")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] [Range(0, 5)]
        private float _shotTimeOut = 0;

        [SerializeField]
        private BulletType _bulletType = 0;

        [SerializeField] [Range(0, 1)]
        private float _shotRandomnessY = 0;

        public float ShotTimeOut => _shotTimeOut;

        public BulletType BulletType => _bulletType;

        public float ShotRandomnessY => _shotRandomnessY;

    }
}