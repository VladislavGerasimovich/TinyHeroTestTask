using UnityEngine;

namespace Enemies.Stats
{
    public class HitDamage : MonoBehaviour
    {
        [SerializeField] private float _value;

        public float Value => _value;
    }
}