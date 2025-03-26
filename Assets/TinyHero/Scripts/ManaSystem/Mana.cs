using System.Collections;
using UI.Bars;
using UnityEngine;

namespace Player.PlayerStats
{
    [RequireComponent(typeof(View))]
    public class Mana : MonoBehaviour
    {
        [SerializeField] private float _maxValue;
        [SerializeField] private ManaRestorer _manaRestorer;

        private View _manaView;
        private Coroutine _replenishRoutine;

        public float CurrentValue { get; private set; }

        private void Awake()
        {
            _manaView = GetComponent<View>();
            CurrentValue = _maxValue;
        }

        public void Reduce(float value)
        {
            CurrentValue -= value;

            if (_replenishRoutine == null)
            {
                _replenishRoutine = StartCoroutine(Replenish());
            }

            if (CurrentValue < 0)
            {
                CurrentValue = 0;
                StopCoroutine(_replenishRoutine);
                _replenishRoutine = null;
            }

            _manaView.Set(CurrentValue, _maxValue);
        }

        private IEnumerator Replenish()
        {
            while (CurrentValue < _maxValue)
            {
                yield return new WaitForSeconds(_manaRestorer.RecoverySpeed);

                CurrentValue += _manaRestorer.RestoredValue;
                _manaView.Set(CurrentValue, _maxValue);
            }

            _replenishRoutine = null;
        }
    }
}