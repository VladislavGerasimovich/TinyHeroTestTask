using UnityEngine;

public class BoostPercent : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _valueOfReload;
    [SerializeField] private float _timeOfAction;
    [SerializeField] private float _manaCost;

    public float Value => _value;
    public float ValueOfReload => _valueOfReload;
    public float TimeOfAction => _timeOfAction;
    public float ManaCost => _manaCost;
}
