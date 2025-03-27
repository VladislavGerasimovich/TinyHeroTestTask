using UnityEngine;

namespace Enemies.Stats
{
    public class HitReload : MonoBehaviour
    {
        [SerializeField] private float _value;

        public float Value => _value;
    }
}