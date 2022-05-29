using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(fileName = "ParticlesData", menuName = "SciptableObjects/Data/ParticlesData")]
    public class ParticlesData : ScriptableObject
    {
        [SerializeField] private List<ParticleSystem> _particles = default;

        public List<ParticleSystem> Particles => _particles;
    }
}