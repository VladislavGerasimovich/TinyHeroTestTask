using System.Collections;
using UnityEngine;

public class StanStatus : MonoBehaviour
{
    public bool IsSuspended { get; private set; }

    public void Set(float time)
    {
        IsSuspended = true;
        StartCoroutine(Perform(time));
    }

    private IEnumerator Perform(float time)
    {
        while(time > 0)
        {
            time -= Time.fixedDeltaTime;

            yield return null;
        }

        IsSuspended = false;
    }
}
