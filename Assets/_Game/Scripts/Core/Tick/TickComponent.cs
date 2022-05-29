using UnityEngine;

namespace Game.Scripts.Core
{
    /// <summary>
    /// Sub-components of game objects should be inherited from this.
    /// </summary>
    public abstract class TickComponent : MonoBehaviour, ITickComponent
    {
        protected int id;

        public int Id => id;

        public void SetId(int tickId)
        {
            id = tickId;
        }

        public virtual void Init()
        {
            // Override this method without base;
        }

        public virtual void Enable()
        {
            // Override this method without base;
        }

        public virtual void PhysicsTick()
        {
            // Override this method without base;
        }

        public virtual void Tick()
        {
            // Override this method without base;
        }

        public virtual void CameraTick()
        {
            // Override this method without base;
        }

        public virtual void Disable()
        {
            // Override this method without base;
        }

        public virtual void Dispose()
        {
            // Override this method without base;
        }
    }
}
