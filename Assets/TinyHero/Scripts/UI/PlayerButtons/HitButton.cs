using System;
using UnityEngine;

namespace UI.PlayerButtons
{
    public class HitButton : PressButton
    {
        [SerializeField] private TimeOfAction _timeOfAction;

        public event Action Clicked;

        public override void OnButtonClick()
        {
            Clicked?.Invoke();
        }

        public void Reload()
        {
            _timeOfAction.StartRunCoroutine(1.3f);
        }
    }
}