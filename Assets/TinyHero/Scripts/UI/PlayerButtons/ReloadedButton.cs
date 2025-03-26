using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerButtons
{
    [RequireComponent(typeof(Reload))]
    public class ReloadedButton : PressButton
    {
        [SerializeField] private TimeOfAction _timeOfAction;

        public Reload ReloadValue;

        public event Action Clicked;

        private void Awake()
        {
            Button = GetComponent<Button>();
            ReloadValue = GetComponent<Reload>();
        }

        public override void OnButtonClick()
        {
            Clicked?.Invoke();
        }

        public void Reload()
        {
            _timeOfAction.StartRunCoroutine(ReloadValue.Value);
        }
    }
}