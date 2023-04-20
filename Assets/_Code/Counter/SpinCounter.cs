using System.Collections.Generic;
using _Code.Counter;
using _Code.Data;
using _Code.Wheel;
using UnityEngine;
using UnityEngine.UI;

namespace _Code
{
    public class SpinCounter : MonoBehaviour
    {
        private HorizontalLayoutGroup _layoutGroup;
        private List<CounterNumber> _counterNumbers;
        private int _lastCount = 7;

        void Awake()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent += OnSpinEnd;

            TryCacheComponents();
        }

        private void OnDisable()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent -= OnSpinEnd;
        }

        private void TryCacheComponents()
        {
            if (_layoutGroup != null) return;

            _layoutGroup = GetComponentInChildren<HorizontalLayoutGroup>();
            _counterNumbers = new List<CounterNumber>(_layoutGroup.GetComponentsInChildren<CounterNumber>());
        }

        private void OnSpinEnd(ItemData itemData)
        {
            for (int i = _counterNumbers.Count - 1; i > 0; i--)
            {
                var newPos = _counterNumbers[i - 1].transform.position;
                _counterNumbers[i].ChangePosition(newPos);
            }

            SendFirstCountToBack();
        }

        private void SendFirstCountToBack()
        {
            var newPos = _counterNumbers[^1].transform.position;
            _counterNumbers[0].SendToBack(newPos);
            _counterNumbers[0].UpdateNumberAndColor(_lastCount += 1);

            var temp = _counterNumbers[0];
            _counterNumbers.RemoveAt(0);
            _counterNumbers.Add(temp);
        }
    }
}