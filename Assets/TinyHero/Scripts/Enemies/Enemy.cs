using Enemies.Abilities.EnemyAttack;
using HealthSystem;
using UI;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(EnemyHealth))]
    [RequireComponent(typeof(EnemyMove))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Highlight _highlight;
        [SerializeField] private EnemyAttack _attack;
        [SerializeField] private StanStatus _stanStatus;

        private EnemyHealth _health;
        private EnemyMove _movement;

        public EnemyHealth Health => _health;
        public Highlight Highlight => _highlight;
        public EnemyAttack EnemyAttack => _attack;
        public StanStatus StanStatus => _stanStatus;

        private void Awake()
        {
            _health = GetComponent<EnemyHealth>();
            _movement = GetComponent<EnemyMove>();
        }

        public void Create(Transform startPosition, Point point)
        {
            transform.position = startPosition.transform.localPosition;
            gameObject.SetActive(true);
            EnemyStatus enemyStatus = gameObject.GetComponent<EnemyStatus>();
            enemyStatus.Init(point);
            point.ProhibitUse();
            _health.RestoreAllHealth();

            if (startPosition != point.transform)
            {
                _movement.Perform(point.transform);

                return;
            }

            EnemyAttack.Run();
        }
    }
}