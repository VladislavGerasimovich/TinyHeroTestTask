using UI;
using UI.Bars;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float _maxValue;
        [SerializeField] private View _healthView;
        [SerializeField] private Highlight _highlight;

        public float CurrentValue { get; private set; }

        public Highlight Highlight => _highlight;

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