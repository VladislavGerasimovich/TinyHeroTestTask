using UnityEngine;

namespace UI.PlayerButtons
{
    public class Reload : MonoBehaviour
    {
        [SerializeField] private float _startValue;

        private float _currentValue;
        private float _percentMultiplier;

        public float Value => _currentValue;

        private void Awake()
        {
            _percentMultiplier = 100;
            _currentValue = _startValue;
        }

        public void IncreaseByPercent(float value)
        {
            Debug.Log(Value + " ��");
            _currentValue += _currentValue * value / _percentMultiplier;
            Debug.Log(Value + " �����");
        }

        public void ResetToOriginalValue()
        {
            _currentValue = _startValue;
        }
    }
}