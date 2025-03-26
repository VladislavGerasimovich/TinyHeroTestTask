using UnityEngine;

namespace Player.PlayerStats
{
    public class HitDamage : MonoBehaviour
    {
        [SerializeField] private float _startValue;
        [SerializeField] private float _manaCost;

        private float _currentValue;
        private float _percentMultiplier;

        public float Value => _currentValue;
        public float ManaCost => _manaCost;

        private void Awake()
        {
            _currentValue = _startValue;
            _percentMultiplier = 100f;
        }

        public void IncreaseByPercent(float value)
        {
            _currentValue += _currentValue * value / _percentMultiplier;
        }

        public void ResetToOriginalValue()
        {
            _currentValue = _startValue;
        }
    }
}