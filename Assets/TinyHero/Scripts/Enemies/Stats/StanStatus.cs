using System.Collections;
using UnityEngine;

public class StanStatus : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private AnimatorData _animatorData;

    public bool IsSuspended { get; private set; }

    public void Init(AnimatorData animatorData)
    {
        _animatorData = animatorData;
    }

    public void Set(float time)
    {
        IsSuspended = true;
        StartCoroutine(Perform(time));
    }

    private IEnumerator Perform(float time)
    {
        _animator.SetBool(_animatorData.Stan, true);

        while (time > 0)
        {
            time -= Time.fixedDeltaTime;

            yield return null;
        }

        _animator.SetBool(_animatorData.Stan, false);
        IsSuspended = false;
    }
}
