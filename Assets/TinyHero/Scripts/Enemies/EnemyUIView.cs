using UnityEngine;
using UnityEngine.UI;

namespace Enemies
{
    public class EnemyUIView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _arrowIcon;

        public void SwitchOn()
        {
            _canvasGroup.alpha = 1.0f;
        }

        public void SwitchOff()
        {
            _canvasGroup.alpha = 0f;
            _arrowIcon.enabled = false;
        }
    }
}