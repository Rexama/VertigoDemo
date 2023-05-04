using DG.Tweening;
using Item;
using Tools;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Wheel
{
    public class WheelSpinManager : MonoBehaviour
    {
        [SerializeField] private Transform pivot;
        [SerializeField] private StoredItemFactory storedItemFactory;

        private int _prevIndex = 0;

        public void SpinWheel(Wheel wheel)
        {
            var wheelSettings = wheel.wheelSettings;
            var cycleCount = Random.Range(wheelSettings.minCycleCount, wheelSettings.maxCycleCount);
            var itemNumber = Random.Range(0, wheelSettings.itemCount);

            var angle = itemNumber * wheelSettings.wheelDegree / wheelSettings.itemCount;
            var rotationAngle = cycleCount * wheelSettings.wheelDegree + angle;

            pivot.transform.DORotate(new Vector3(0, 0, rotationAngle), wheelSettings.spinDuration,
                    RotateMode.LocalAxisAdd)
                .OnComplete(() =>
                {
                    var index = (itemNumber + _prevIndex) % wheelSettings.itemCount;
                    var itemObjectData = wheel.wheelItems[index].GetItemObjectData();
                    _prevIndex = index;

                    DOTween.Sequence().AppendInterval(wheelSettings.delayAfterSpin).OnComplete(() =>
                    {
                        if (itemObjectData.ItemData == wheel.allItemData.bombItem)
                        {
                            EventBus.Trigger("OnBombSelected");
                        }
                        else
                        {
                            EventBus.Trigger("OnItemSelected");
                            storedItemFactory.AddStoredItems(itemObjectData);
                        }
                    });
                });
        }
    }
}