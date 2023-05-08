using System.Collections.Generic;
using Tools;
using UnityEngine;
using Wheel;

namespace Counter
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private WheelSettings wheelSettings;
        [SerializeField] private List<CounterNumber> counterNumbers;
        
        private int _lastCount = 7;

        private void Awake()
        {
            EventBus.Subscribe("OnItemSelected", ShiftCounterNumbers);
            EventBus.Subscribe("OnBombSelected", ShiftCounterNumbers);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe("OnItemSelected", ShiftCounterNumbers);
            EventBus.Unsubscribe("OnBombSelected", ShiftCounterNumbers);
        }


        private void ShiftCounterNumbers()
        {
            for (var i = counterNumbers.Count - 1; i > 0; i--)
            {
                var newPos = counterNumbers[i - 1].transform.position;
                counterNumbers[i].ChangePosition(newPos);
            }

            SendFirstCounterNumberToBack();
        }

        private void SendFirstCounterNumberToBack()
        {
            var newPos = counterNumbers[^1].transform.position;
            var newCount = _lastCount += 1;
            var newColor = wheelSettings.GetWheelTypeWithSpinCount(newCount).counterNumberColor;
            counterNumbers[0].SendToBack(newPos);
            counterNumbers[0].UpdateNumberAndColor(newColor, newCount);

            var temp = counterNumbers[0];
            counterNumbers.RemoveAt(0);
            counterNumbers.Add(temp);
        }
    }
}