namespace Game.Scripts.Core
{
    public interface IBullet
    {
        int OwnerId { get; }

        float DamageAmount { get; }
    }
}
