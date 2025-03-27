using Enemies;
using Enemies.Abilities.EnemyAttack;
using UnityEngine;

namespace HealthSystem
{
    [RequireComponent(typeof(EnemyStatus))]
    [RequireComponent(typeof(EnemyUIView))]
    public class EnemyHealth : Health
    {
        [SerializeField] private EnemyAttack _enemyAttack;

        private EnemyStatus _enemyStatus;
        private EnemyUIView _enemyUIView;

        protected override void Awake()
        {
            base.Awake();
            _enemyStatus = GetComponent<EnemyStatus>();
            _enemyUIView = GetComponent<EnemyUIView>();
        }

        protected override void Die()
        {
            _enemyAttack.Stop();
            base.Die();
            _enemyStatus.ResetPoint();
            _enemyUIView.SwitchOff();
        }
    }
}