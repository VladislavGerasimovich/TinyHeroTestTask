using Enemies;
using Game.ObjectPools;
using UnityEngine;

namespace GameSession
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private AttackPoints _attackPoints;

        private void Awake()
        {
            _enemyPool.Initialize();

            for (int i = 0; i < _attackPoints.Count; i++)
            {
                Point point = _attackPoints.GetPointByIndex(i);
                bool isEnemy = _enemyPool.TryGet(out GameObject gameObject);

                if (isEnemy == true) {
                    gameObject.transform.position = point.transform.position;
                    gameObject.SetActive(true);
                }
            }
        }
    }
}