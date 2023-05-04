using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.UI;
using Wheel;

namespace Counter
{
    public class SpinCounter : MonoBehaviour
    {
        [SerializeField] private WheelSettings wheelSettings;

        private HorizontalLayoutGroup _layoutGroup;
        private List<CounterNumber> _counterNumbers;
        private int _lastCount = 7;

        private void Awake()
        {
            EventBus.Subscribe("OnItemSelected", OnSpinEnd);
            EventBus.Subscribe("OnBombSelected", OnSpinEnd);

            CacheComponents();
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe("OnItemSelected", OnSpinEnd);
            EventBus.Unsubscribe("OnBombSelected", OnSpinEnd);
        }

        private void CacheComponents()
        {
            _layoutGroup = GetComponentInChildren<HorizontalLayoutGroup>();
            _counterNumbers = new List<CounterNumber>(_layoutGroup.GetComponentsInChildren<CounterNumber>());
        }

        private void OnSpinEnd()
        {
            for (var i = _counterNumbers.Count - 1; i > 0; i--)
            {
                var newPos = _counterNumbers[i - 1].transform.position;
                _counterNumbers[i].ChangePosition(newPos);
            }

            SendFirstCountToBack();
        }

        private void SendFirstCountToBack()
        {
            var newPos = _counterNumbers[^1].transform.position;
            var newCount = _lastCount += 1;
            var newColor = wheelSettings.GetWheelTypeWithSpinCount(newCount).counterNumberColor;
            _counterNumbers[0].SendToBack(newPos);
            _counterNumbers[0].UpdateNumberAndColor(newColor, newCount);

            var temp = _counterNumbers[0];
            _counterNumbers.RemoveAt(0);
            _counterNumbers.Add(temp);
        }
    }
}