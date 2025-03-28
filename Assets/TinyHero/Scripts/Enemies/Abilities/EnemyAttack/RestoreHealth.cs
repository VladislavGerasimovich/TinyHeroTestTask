using HealthSystem;
using UnityEngine;

namespace Enemies.Abilities.EnemyAttack
{
    public class RestoreHealth : MonoBehaviour
    {
        [SerializeField] private float _count;
        [SerializeField] private float _percentOfChance;
        [SerializeField] private EnemyHealth _health;

        private float _minPercent;
        private float _maxPercent;

        private void Awake()
        {
            _minPercent = 0;
            _maxPercent = 101;
        }

        public bool Perform()
        {
            if (Random.Range(_minPercent, _maxPercent) < _percentOfChance)
            {
                _health.Restore(_count);

                return true;
            }

            return false;
        }
    }
}