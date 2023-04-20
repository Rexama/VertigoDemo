using _Code.Data;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Code.Counter
{
    public class CounterNumber : MonoBehaviour
    {
        private CountColors _countColors;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            TryCacheComponents();
        }

        private void TryCacheComponents()
        {
            if (_text != null) return;

            _text = GetComponent<TextMeshProUGUI>();
            _countColors = Resources.Load<CountColors>("CountColors");
        }

        public void UpdateNumberAndColor(int number)
        {
            _text.text = number.ToString();

            UpdateColor(number);
        }

        private void UpdateColor(int number)
        {
            if (number % 30 == 0)
            {
                _text.color = _countColors.goldenCounterColor;
            }
            else if (number % 5 == 0)
            {
                _text.color = _countColors.silverCounterColor;
            }
            else
            {
                _text.color = _countColors.bronzeCounterColor;
            }
        }

        public void ChangePosition(Vector3 position)
        {
            transform.DOMove(position, 0.5f).SetEase(Ease.OutBounce);
        }

        public void SendToBack(Vector3 position)
        {
            transform.position = position;
        }
    }
}