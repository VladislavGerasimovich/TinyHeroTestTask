using Enemies.Abilities.EnemyAttack;
using System.Collections;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(EnemyUIView))]
    [RequireComponent(typeof(Animator))]
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private EnemyAttack _enemyAttack;

        private AnimatorData _animatorData;
        private float _speed;
        private EnemyUIView _enemyUIView;
        private Animator _animator;
        private Collider2D _collider;

        private void Awake()
        {
            _speed = 5f;
            _enemyUIView = GetComponent<EnemyUIView>();
            _animator = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();
        }

        public void Init(AnimatorData animatorData)
        {
            _animatorData = animatorData;
        }

        public void Perform(Transform target)
        {
            StartCoroutine(RunRoutine(target));
        }

        private IEnumerator RunRoutine(Transform target)
        {
            _collider.enabled = false;
            _animator.SetBool(_animatorData.Move, true);

            while (transform.position != target.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * _speed);

                yield return null;
            }

            _collider.enabled = true;
            _animator.SetBool(_animatorData.Move, false);
            _enemyUIView.SwitchOn();
            _enemyAttack.Run();
        }
    }
}