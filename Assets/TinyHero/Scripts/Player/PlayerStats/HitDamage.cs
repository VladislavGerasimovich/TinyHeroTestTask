using UnityEngine;

namespace Player.PlayerStats
{
    public class HitDamage : MonoBehaviour
    {
        [SerializeField] private float _value;

        public float Value => _value;
    }
}