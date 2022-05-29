using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class AttackComponent : TickComponent
    {
        [SerializeField]
        private BaseStateMachineComponent<MovementState> _movementStateMachineComponent = default;

        [SerializeField] [Space]
        private Transform _bulletRoot = default;

        [SerializeField] [Space]
        private WeaponData _weaponData = default;

        public void UseWeapon()
        {
            base.Tick();
        }
    }
}
