using Game.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class AttackPoints : MonoBehaviour
    {
        [SerializeField] private List<Point> _positions;
        [SerializeField] private Transform _spawnPosition;

        private EnemyPool _enemyPool;

        private void OnEnable()
        {
            foreach (Point point in _positions)
            {
                point.Free += OnPointFreed;
            }
        }

        private void OnDisable()
        {
            foreach (Point point in _positions)
            {
                point.Free -= OnPointFreed;
            }
        }

        public void Init(EnemyPool enemyPool)
        {
            _enemyPool = enemyPool;

            foreach (Point point in _positions)
            {
                TakePoint(point.transform, point);
            }
        }

        private void OnPointFreed()
        {
            Point point = GetFreepoint();
            TakePoint(_spawnPosition, point);
        }

        private IEnumerator TakePointRoutine()
        {
            yield return new WaitForSeconds(2);

        }

        private void TakePoint(Transform startposition, Point point)
        {
            bool isEnemy = _enemyPool.TryGet(out GameObject gameObject);

            if (isEnemy == true)
            {
                Enemy enemy = gameObject.GetComponent<Enemy>();
                enemy.Create(startposition, point);
            }
        }

        private Point GetFreepoint()
        {
            foreach (Point point in _positions)
            {
                if(point.IsBusy == false)
                {
                    return point;
                }
            }

            return null;
        }
    }
}