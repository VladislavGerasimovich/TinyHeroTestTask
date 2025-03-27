using Enemies;
using Game.ObjectPools;
using HealthSystem;
using Player.PlayerInput;
using UnityEngine;

namespace GameSession
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private AttackPoints _attackPoints;
        [SerializeField] private EnemySeeker _enemySeeker;
        [SerializeField] private PlayerHealth _playerHealth;

        private void Awake()
        {
            _enemyPool.Init(_playerHealth);
            _attackPoints.Init(_enemyPool);
        }
    }
}