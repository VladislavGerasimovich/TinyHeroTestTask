using Enemies;
using HealthSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.ObjectPools
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;
        [SerializeField] private GameObject _prefab;

        private List<GameObject> _pool;

        public bool TryGet(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => p.activeSelf == false);
            return result != null;
        }

        public void Init(PlayerHealth playerHealth)
        {
            _pool = new List<GameObject>();

            for (int i = 0; i < _capacity; i++)
            {
                GameObject item = Instantiate(_prefab, _container.transform);
                item.SetActive(false);
                Enemy enemy = item.GetComponent<Enemy>();
                enemy.EnemyAttack.Init(playerHealth);
                _pool.Add(item);
            }
        }
    }
}