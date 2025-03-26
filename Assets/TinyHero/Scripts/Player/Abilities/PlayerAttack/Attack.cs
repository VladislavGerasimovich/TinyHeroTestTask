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
            if(_enemySeeker.CurrentEnemy != null &&
                _enemySeeker.CurrentEnemy.Health.CurrentValue > 0 &&
                _mana.CurrentValue >= _hitDamage.ManaCost)
            {
                _mana.Reduce(_hitDamage.ManaCost);
                _hitButton.Reload();
                _enemySeeker.CurrentEnemy.Health.Reduce(_hitDamage.Value);
            }
        }
    }
}