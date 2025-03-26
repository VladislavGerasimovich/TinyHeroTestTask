using Player.PlayerStats;
using System.Collections;
using UI.PlayerButtons;
using UnityEngine;

namespace Player.Abilities.PlayerBoost
{
    public class Boost : MonoBehaviour
    {
        [SerializeField] private ReloadedButton _boostButton;
        [SerializeField] private ReloadedButton _hitButton;
        [SerializeField] private BoostPercent _boostPercent;
        [SerializeField] private HitDamage _hitDamage;

        private void OnEnable()
        {
            _boostButton.Clicked += Perform;
        }

        private void OnDisable()
        {
            _boostButton.Clicked -= Perform;
        }

        private void Perform()
        {
            StartCoroutine(RunRoutine());
        }

        private IEnumerator RunRoutine()
        {
            _hitDamage.IncreaseByPercent(_boostPercent.Value);
            _boostButton.Reload();
            _hitButton.ReloadValue.IncreaseByPercent(_boostPercent.ValueOfReload);

            yield return new WaitForSeconds(_boostPercent.TimeOfAction);

            _hitDamage.ResetToOriginalValue();
            _hitButton.ReloadValue.ResetToOriginalValue();
        }
    }
}