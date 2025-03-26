using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.ObjectPools
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] protected GameObject Container;
        [SerializeField] protected int Capacity;
        [SerializeField] private GameObject _prefab;

        private List<GameObject> _pool;

        public bool TryGet(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => p.activeSelf == false);
            return result != null;
        }

        public void Initialize()
        {
            _pool = new List<GameObject>();

            for (int i = 0; i < Capacity; i++)
            {
                GameObject item = Instantiate(_prefab, Container.transform);
                item.SetActive(false);
                _pool.Add(item);
            }
        }
    }
}