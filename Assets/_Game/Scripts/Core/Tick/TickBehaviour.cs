using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    /// <summary>
    /// Entry point for any updatable mono behaviour.
    /// Main component of the game object should be inherited from this.
    /// </summary>
    public abstract class TickBehaviour : MonoBehaviour, ITick
    {
        protected List<ITickComponent> components = new List<ITickComponent>();

        protected GameManager gameManager = default;

        protected TickPriority priority = TickPriority.Normal;

        protected int id = 0;

        public TickPriority Priority => priority;

        public int Id => id;

        [Inject]
        protected void Construct(GameManager loopUpdater)
        {
            gameManager = loopUpdater;
        }

        void Awake()
        {
            Init();
        }

        void OnEnable()
        {
            if (gameManager.CheckIfAttached(this))
                Enable();
        }

        void OnDisable()
        {
            if (gameManager.CheckIfDetached(this))
                Disable();
        }

        void OnDestroy()
        {
            Dispose();
        }

        public void SetId(int tickId)
        {
            id = tickId;

            foreach (var component in components)
                component.SetId(id);
        }

        public virtual void Init()
        {
            // Override this method with base;

            foreach (var component in components)
                component.Init();
        }

        public virtual void Enable()
        {
            // Override this method with base;

            foreach (var component in components)
                component.Enable();
        }

        public virtual void PhysicsTick()
        {
            // Override this method with base;

            foreach (var component in components)
                component.PhysicsTick();
        }

        public virtual void Tick()
        {
            // Override this method with base;

            foreach (var component in components)
                component.Tick();
        }

        public virtual void CameraTick()
        {
            // Override this method with base;

            foreach (var component in components)
                component.CameraTick();
        }

        public virtual void Disable()
        {
            // Override this method with base;

            foreach (var component in components)
                component.Disable();
        }

        public virtual void Dispose()
        {
            // Override this method with base;

            foreach (var component in components)
                component.Dispose();
            components.Clear();
        }

        /// <summary>
        /// Adds <see cref="ITickComponent"/> to the list of updating components.
        /// </summary>
        /// <param name="component"></param>
        protected void AttachComponent(ITickComponent component)
        {
            if (components.Contains(component))
                return;

            components.Add(component);
            component.Init();
        }

        /// <summary>
        /// Removes <see cref="ITickComponent"/> from the list of updating components.
        /// </summary>
        protected void DetachComponent(ITickComponent component)
        {
            if (!components.Contains(component))
                return;

            component.Dispose();
            components.Remove(component);
        }
    }
}
