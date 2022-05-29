using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        private readonly List<ITick> _lowPriorityTicks = new List<ITick>();
        private readonly List<ITick> _normalPriorityTicks = new List<ITick>();
        private readonly List<ITick> _highPriorityTicks = new List<ITick>();

        private readonly List<ITick> _pendingTicks = new List<ITick>();
        private readonly List<ITick> _ticksToRemove = new List<ITick>();

        private int _instanceCounter = 0;
        private int _tick = 0;

        public int Tick => _tick;

        void Awake()
        {
            Application.targetFrameRate = Constants.TargetFrameRate;
            Application.backgroundLoadingPriority = ThreadPriority.Normal;
        }

        void FixedUpdate()
        {
            foreach (var tick in _highPriorityTicks)
                tick.PhysicsTick();

            foreach (var tick in _normalPriorityTicks)
                tick.PhysicsTick();

            foreach (var tick in _lowPriorityTicks)
                tick.PhysicsTick();
        }

        void Update()
        {
            _tick++;

            RemoveRedundantTicks();
            AddPendingTicks();

            foreach (var tick in _highPriorityTicks)
                tick.Tick();

            foreach (var tick in _normalPriorityTicks)
                tick.Tick();

            foreach (var tick in _lowPriorityTicks)
                tick.Tick();
        }

        void LateUpdate()
        {
            foreach (var tick in _highPriorityTicks)
                tick.CameraTick();

            foreach (var tick in _normalPriorityTicks)
                tick.CameraTick();

            foreach (var tick in _lowPriorityTicks)
                tick.CameraTick();
        }

        public bool CheckIfAttached(ITick tick)
        {
            if (tick.Id == 0)
            {
                _instanceCounter++;
                tick.SetId(_instanceCounter);
            }

            switch (tick.Priority)
            {
                case TickPriority.High:
                    {
                        var containsInTickers = _highPriorityTicks.Contains(tick);
                        if (containsInTickers)
                            return false;
                        break;
                    }

                case TickPriority.Normal:
                    {
                        var containsInTickers = _normalPriorityTicks.Contains(tick);
                        if (containsInTickers)
                            return false;
                        break;
                    }
                case TickPriority.Low:
                    {
                        var containsInTickers = _lowPriorityTicks.Contains(tick);
                        if (containsInTickers)
                            return false;
                        break;
                    }
            }

            _pendingTicks.Add(tick);
            return true;
        }

        public bool CheckIfDetached(ITick tick)
        {
            switch (tick.Priority)
            {
                case TickPriority.High:
                    {
                        var containsInTickers = _highPriorityTicks.Contains(tick);
                        if (!containsInTickers)
                            return false;
                        break;
                    }
                case TickPriority.Normal:
                    {
                        var containsInTickers = _normalPriorityTicks.Contains(tick);
                        if (!containsInTickers)
                            return false;
                        break;
                    }
                case TickPriority.Low:
                    {
                        var containsInTickers = _lowPriorityTicks.Contains(tick);
                        if (!containsInTickers)
                            return false;
                        break;
                    }
            }

            _ticksToRemove.Add(tick);

            return true;
        }

        private void AddPendingTicks()
        {
            for (var i = _pendingTicks.Count - 1; i >= 0; i--)
            {
                var tick = _pendingTicks[i];
                switch (tick.Priority)
                {
                    case TickPriority.High:
                    {
                        _highPriorityTicks.Add(tick);
                        break;
                    }

                    case TickPriority.Normal:
                    {
                        _normalPriorityTicks.Add(tick);
                        break;
                    }

                    case TickPriority.Low:
                    {
                        _lowPriorityTicks.Add(tick);
                        break;
                    }
                }

                _pendingTicks.RemoveAt(i);
            }
        }

        private void RemoveRedundantTicks()
        {
            for (var i = _ticksToRemove.Count - 1; i >= 0; i--)
            {
                var tick = _ticksToRemove[i];
                switch (tick.Priority)
                {
                    case TickPriority.High:
                    {
                        _highPriorityTicks.Remove(tick);
                        break;
                    }

                    case TickPriority.Normal:
                    {
                        _normalPriorityTicks.Remove(tick);
                        break;
                    }

                    case TickPriority.Low:
                    {
                        _lowPriorityTicks.Remove(tick);
                        break;
                    }
                }

                _ticksToRemove.RemoveAt(i);
            }
        }
    }
}
