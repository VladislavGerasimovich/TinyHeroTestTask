using UnityEngine;

public class BoostPercent : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _valueOfReload;
    [SerializeField] private float _timeOfAction;

    public float Value => _value;
    public float ValueOfReload => _valueOfReload;
    public float TimeOfAction => _timeOfAction;
}
