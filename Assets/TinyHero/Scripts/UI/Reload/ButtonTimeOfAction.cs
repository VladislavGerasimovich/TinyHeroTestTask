using UnityEngine;
using UnityEngine.UI;

namespace UI.Reload
{
    [RequireComponent(typeof(Image))]
    public class ButtonTimeOfAction : TimeOfAction
    {
        [SerializeField] private Button _button;

        public override void StartRunCoroutine(float time)
        {
            _button.interactable = false;
            base.StartRunCoroutine(time);
        }

        public override void StopRunCoroutine()
        {
            base.StopRunCoroutine();
            _button.interactable = true;
        }
    }
}