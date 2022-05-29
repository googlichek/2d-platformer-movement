using Game.Scripts.Data;

namespace Game.Scripts.Core
{
    public interface IBullet
    {
        BulletType Type { get; }

        int OwnerId { get; }

        float DamageAmount { get; }
    }
}
