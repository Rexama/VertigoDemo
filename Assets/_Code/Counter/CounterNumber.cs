using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Counter
{
    public class CounterNumber : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countText;

        private const float ChangePositionDuration = 0.5f;

        public void UpdateNumberAndColor(Color color, int number)
        {
            UpdateNumber(number);
            UpdateColor(color);
        }

        private void UpdateColor(Color color)
        {
            countText.color = color;
        }

        private void UpdateNumber(int number)
        {
            countText.text = number.ToString();
        }

        public void ChangePosition(Vector3 position)
        {
            transform.DOMove(position, ChangePositionDuration).SetEase(Ease.OutBounce);
        }

        public void SendToBack(Vector3 position)
        {
            transform.position = position;
        }
    }
}