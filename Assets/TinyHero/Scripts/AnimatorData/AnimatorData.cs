using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public readonly int Attack = Animator.StringToHash(nameof(Attack));
    public readonly int Move = Animator.StringToHash(nameof(Move));
    public readonly int Stan = Animator.StringToHash(nameof(Stan));
}