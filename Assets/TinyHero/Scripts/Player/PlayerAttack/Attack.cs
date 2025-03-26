using Player.PlayerInput;
using Player.PlayerStats;
using UI.PlayerButtons;
using UnityEngine;

namespace Player.PlayerAttack
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private HitButton _hitButton;
        [SerializeField] private HitDamage _hitDamage;
        [SerializeField] private EnemySeeker _enemySeeker;

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
            if(_enemySeeker.CurrentEnemyHealth != null && _enemySeeker.CurrentEnemyHealth.CurrentValue > 0)
            {
                _hitButton.Reload();
                _enemySeeker.CurrentEnemyHealth.Reduce(_hitDamage.Value);
            }
        }
    }
}