using UnityEngine;

namespace Player.PlayerStats
{
    public class ManaRestorer : MonoBehaviour
    {
        [SerializeField] private float _restoredValue;
        [SerializeField] private float _recoverySpeed;

        public float RestoredValue => _restoredValue;
        public float RecoverySpeed => _recoverySpeed;
    }
}