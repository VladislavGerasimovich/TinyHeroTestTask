using UI.Bars;
using UnityEngine;

namespace HealthSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected float MaxValue;
        [SerializeField] private View _healthView;

        protected float Current;

        public float CurrentValue => Current;

        protected virtual void Awake()
        {
            Current = MaxValue;
        }

        public void RestoreAllHealth()
        {
            Current = MaxValue;
            _healthView.Set(Current, MaxValue);
        }

        public void Reduce(float value)
        {
            Current -= value;
            
            if(Current <= 0)
            {
                Current = 0;
                Die();
            }

            _healthView.Set(Current, MaxValue);
        }

        public virtual void Restore(float value)
        {
            Current += value;

            if(Current > MaxValue)
            {
                Current = MaxValue;
            }

            _healthView.Set(Current, MaxValue);
        }

        protected virtual void Die()
        {
            gameObject.SetActive(false);
        }
    }
}