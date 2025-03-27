using Enemies.Abilities.EnemyAttack;
using System.Collections;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(EnemyUIView))]
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private EnemyAttack _enemyAttack;

        private float _speed;
        private EnemyUIView _enemyUIView;

        private void Awake()
        {
            _speed = 5f;
            _enemyUIView = GetComponent<EnemyUIView>();
        }

        public void Perform(Transform target)
        {
            StartCoroutine(RunRoutine(target));
        }

        private IEnumerator RunRoutine(Transform target)
        {
            while (transform.position != target.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * _speed);

                yield return null;
            }

            _enemyUIView.SwitchOn();
            _enemyAttack.Run();
        }
    }
}