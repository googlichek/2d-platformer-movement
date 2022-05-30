using System.Collections;
using Game.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class WeaponComponent : TickComponent
    {
        [SerializeField]
        private WeaponData _data = default;

        [SerializeField] [Space]
        private Transform _bulletRoot = default;

        private BulletPool _bulletPool = default;

        private float _shotCooldownTime = 0;

        public bool IsInUse => _shotCooldownTime > 0;

        [Inject]
        public void Construct(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public override void Tick()
        {
            if (_shotCooldownTime < 0)
                return;

            _shotCooldownTime -= Time.deltaTime;
        }

        public void Use()
        {
            if (_shotCooldownTime > 0)
                return;

            _shotCooldownTime = _data.ShotTimeOut;

            var shootCoroutine = StartCoroutine(Shoot(_shotCooldownTime * 0.5f));
        }

        private IEnumerator Shoot(float delay)
        {
            yield return new WaitForSeconds(delay);

            var directionSign = Mathf.FloorToInt(transform.localScale.x);

            var bullet = _bulletPool.GetBullet(_data.BulletType);
            bullet.Setup(_bulletPool, id);

            var velocityRandomY = Random.Range(-_data.ShotRandomnessY, _data.ShotRandomnessY);
            var shotRandomizer = new Vector3(0, velocityRandomY, 0);

            bullet.transform.SetPositionAndRotation(_bulletRoot.position, _bulletRoot.rotation);
            bullet.Body.velocity =
                (Vector3.right + shotRandomizer) * directionSign * bullet.Data.Speed;
        }
    }
}
