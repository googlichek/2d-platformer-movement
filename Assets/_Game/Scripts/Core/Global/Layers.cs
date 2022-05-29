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

        StaticSurface = 13,
        DynamicSurface = 14,
        StairsSimplified = 15,
        StairsRough = 16,

        Interactable = 18,

        PostProcessing = 31
    }
}
