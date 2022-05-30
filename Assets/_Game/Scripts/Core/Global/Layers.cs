namespace Game.Scripts.Core
{
    public enum Layers
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        Water = 4,
        UI = 5,

        Player = 8,
        Enemy = 9,
        NPC = 10,

        InvisibleWall = 12,
        StaticSurface = 13,
        DynamicSurface = 14,
        StairsSimplified = 15,
        StairsRough = 16,

        Interactable = 18,

        Projectile = 21,
        ProjectileShard = 22,

        PostProcessing = 31
    }
}
