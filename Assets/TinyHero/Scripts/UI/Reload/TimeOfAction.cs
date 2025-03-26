using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class TimeOfAction : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private Image _image;

        private Coroutine _runCoroutine;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void StartRunCoroutine(float time)
        {
            _runCoroutine = StartCoroutine(Run(time));
        }

        public void StopRunCoroutine()
        {
            StopCoroutine(_runCoroutine);
            _image.fillAmount = 0;
        }

        private IEnumerator Run(float time)
        {
            _button.interactable = false;
            _image.fillAmount = 0;
            float duration = 0;

            while (_image.fillAmount < 1)
            {
                duration += Time.deltaTime;
                _image.fillAmount = duration / time;

                yield return null;
            }

            _image.fillAmount = 0;
            _button.interactable = true;
        }
    }
}