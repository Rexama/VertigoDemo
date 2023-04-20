using System;
using _Code.Data;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


namespace _Code.Wheel
{
    public class WheelSpinManager : MonoBehaviour
    {
        [SerializeField] public int itemCount = 8;
        [SerializeField] private int minCycleCount = 2;
        [SerializeField] private int maxCycleCount = 3;
        [SerializeField] private float spinDuration = 4;
        [SerializeField] private float delayAfterSpin = 0.3f;

        private int _prevIndex = 0;
        private Wheel _wheel;
        private Transform _pivot;

        public static event Action<ItemData> OnWheelSpinCompleteEvent;

        private void Awake()
        {
            TryCacheComponents();
        }

        private void TryCacheComponents()
        {
            if (_wheel != null) return;

            _wheel = GetComponent<Wheel>();
            _pivot = transform.GetChild(0).transform;
        }

        public void SpinWheel()
        {
            var cycleCount = Random.Range(minCycleCount, maxCycleCount);
            var itemNumber = Random.Range(0, itemCount);

            var angle = itemNumber * 360 / itemCount;
            var rotationAngle = cycleCount * 360 + angle;

            _pivot.transform.DORotate(new Vector3(0, 0, rotationAngle), spinDuration, RotateMode.LocalAxisAdd)
                .OnComplete(() =>
                {
                    var index = (itemNumber + _prevIndex) % itemCount;
                    var itemData = _wheel.items[index].GetItemData();
                    _prevIndex = index;

                    DOTween.Sequence().AppendInterval(delayAfterSpin).OnComplete(() =>
                    {
                        OnWheelSpinCompleteEvent?.Invoke(itemData);
                    });
                });
        }
    }
}