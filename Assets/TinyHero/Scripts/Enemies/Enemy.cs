using HealthSystem;
using UI;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Highlight _highlight;

        private Health _health;

        public Health Health => _health;
        public Highlight Highlight => _highlight;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }
    }
}