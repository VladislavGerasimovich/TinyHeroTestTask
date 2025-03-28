using Player.PlayerInput;
using Player.PlayerStats;
using UI.PlayerButtons;
using UnityEngine;

namespace Player.Abilities.PlayerAttack
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private ReloadedButton _hitButton;
        [SerializeField] private HitDamage _hitDamage;
        [SerializeField] private EnemySeeker _enemySeeker;
        [SerializeField] private Mana _mana;
        [SerializeField] private Stan _stan;
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorData _animatorData;

        private void OnEnable()
        {
            _hitButton.Clicked += Perform;
        }

        private void OnDisable()
        {
            _hitButton.Clicked -= Perform;
        }

        private void Perform()
        {
            if (_enemySeeker.CurrentEnemy != null &&
                _enemySeeker.CurrentEnemy.Health.CurrentValue > 0 &&
                _mana.CurrentValue >= _hitDamage.ManaCost)
            {
                _mana.Reduce(_hitDamage.ManaCost);
                _hitButton.Reload();
                _animator.SetTrigger(_animatorData.Attack);

                if ((_enemySeeker.CurrentEnemy.Health.CurrentValue - _hitDamage.Value) > 0)
                {
                    _enemySeeker.CurrentEnemy.Health.Reduce(_hitDamage.Value);
                    bool isStanned = _stan.TryPerform();

                    if (isStanned == true)
                    {
                        _enemySeeker.CurrentEnemy.StanStatus.Set(_stan.Duration);
                    }
                    return;
                }

                _enemySeeker.CurrentEnemy.Health.Reduce(_hitDamage.Value);
                _enemySeeker.ResetCurrentEnemy();
            }
        }
    }
}