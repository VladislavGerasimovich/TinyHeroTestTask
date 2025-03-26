using UI;
using UI.Bars;
using UnityEngine;

namespace HealthSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxValue;
        [SerializeField] private View _healthView;

        public float CurrentValue { get; private set; }

        private void Awake()
        {
            CurrentValue = _maxValue;
        }

        public void Reduce(float value)
        {
            CurrentValue -= value;
            
            if(CurrentValue < 0)
            {
                CurrentValue = 0;
            }

            _healthView.Set(CurrentValue, _maxValue);
        }
    }
}