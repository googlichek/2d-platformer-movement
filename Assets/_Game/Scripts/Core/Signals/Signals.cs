using UnityEngine;

namespace Game.Scripts.Core
{
    public static class Signals
    {
        public class HumanSpawnedSignal
        {
            public GameObject Human { get; }

            public HumanSpawnedSignal(GameObject human)
            {
                Human = human;
            }
        }
    }
}
