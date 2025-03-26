using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Bars
{
    public class View : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private TMP_Text _textCount;

        public void Set(float count, float maxCount)
        {
            _healthBar.fillAmount = count / maxCount;
            _textCount.text = count.ToString();
        }
    }
}