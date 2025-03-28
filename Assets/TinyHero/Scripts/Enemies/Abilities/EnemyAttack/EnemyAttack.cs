using Enemies.Stats;
using HealthSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Enemies.Abilities.EnemyAttack
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private StanStatus _stanStatus;
        [SerializeField] private HitDamage _hitDamage;
        [SerializeField] private HitReload _hitReload;
        [SerializeField] private RestoreHealth _restoreHealth;
        [SerializeField] private Image _fillImage;
        [SerializeField] private Animator _animator;

        private AnimatorData _animatorData;
        private Health _playerHealth;
        private Coroutine PerformRoutine;

        public void Init(Health playerHealth, AnimatorData animatorData)
        {
            _playerHealth = playerHealth;
            _animatorData = animatorData;
        }

        public void Run()
        {
            if(PerformRoutine == null)
            {
                PerformRoutine = StartCoroutine(Perform());
            }
        }

        public void Stop()
        {
            if(PerformRoutine != null)
            {
                StopCoroutine(PerformRoutine);
                PerformRoutine = null;
            }
        }

        private IEnumerator Perform()
        {
            _fillImage.fillAmount = 0;
            float duration;

            while (enabled)
            {
                duration = 0;

                while (_fillImage.fillAmount < 1)
                {
                    if (_stanStatus.IsSuspended == false)
                    {
                        duration += Time.deltaTime;
                        _fillImage.fillAmount = duration / _hitReload.Value;
                    }

                    yield return null;
                }

                _fillImage.fillAmount = 0;
                _animator.SetTrigger(_animatorData.Attack);
                _playerHealth.Reduce(_hitDamage.Value);
                _restoreHealth.Perform();
            }
        }
    }
}