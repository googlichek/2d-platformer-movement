using System.Collections.Generic;
using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class ParticlesComponent : TickComponent
    {
        [SerializeField]
        private ParticlesData _data = default;

        private readonly List<ParticleSystem> _particles = new();

        public override void Init()
        {
            foreach (var particle in _data.Particles)
            {
                var particleComponent= Instantiate(particle, transform);
                _particles.Add(particleComponent);
            }
        }

        public override void Dispose()
        {
            foreach (var particle in _particles)
                DestroyImmediate(particle);
            _particles.Clear();
        }

        public void Emit()
        {
            foreach (var particle in _particles)
                particle.Play();
        }
    }
}
