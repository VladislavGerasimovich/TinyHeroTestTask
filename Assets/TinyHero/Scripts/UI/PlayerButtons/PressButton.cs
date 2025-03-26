using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerButtons
{
    [RequireComponent(typeof(Button))]
    public class PressButton : MonoBehaviour
    {
        protected Button Button;

        private void Awake()
        {
            Button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            Button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnButtonClick);
        }

        public virtual void OnButtonClick()
        { }
    }
}