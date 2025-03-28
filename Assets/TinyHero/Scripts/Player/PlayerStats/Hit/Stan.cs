using UnityEngine;

public class Stan : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _percentOfChance;

    private float _minPercent;
    private float _maxPercent;

    public float Duration => _duration;

    private void Awake()
    {
        _minPercent = 0;
        _maxPercent = 101;
    }

    public bool TryPerform()
    {
        if (Random.Range(_minPercent, _maxPercent) < _percentOfChance)
        {
            return true;
        }

        return false;
    }
}
