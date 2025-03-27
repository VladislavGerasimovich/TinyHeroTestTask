using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Reload
{
    [RequireComponent(typeof(Image))]
    public class TimeOfAction : MonoBehaviour
    {
        private Image _image;
        private Coroutine _runCoroutine;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public virtual void StartRunCoroutine(float time)
        {
            _runCoroutine = StartCoroutine(Run(time));
        }

        public virtual void StopRunCoroutine()
        {
            StopCoroutine(_runCoroutine);
            _image.fillAmount = 0;
        }

        private IEnumerator Run(float time)
        {
            _image.fillAmount = 0;
            float duration = 0;

            while (_image.fillAmount < 1)
            {
                duration += Time.deltaTime;
                _image.fillAmount = duration / time;

                yield return null;
            }

            StopRunCoroutine();
        }
    }
}