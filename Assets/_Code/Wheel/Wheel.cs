using System.Collections.Generic;
using Item;
using Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Wheel
{
    public class Wheel : MonoBehaviour
    {
        [SerializeField] public AllItemData allItemData;
        [SerializeField] public WheelSettings wheelSettings;
        [SerializeField] public List<ItemObject> wheelItems;
        
        [SerializeField] private WheelImageManager wheelImageManager;
        [SerializeField] private WheelSpinManager wheelSpinManager;
        
        private int _spinCount = 1;

        private void Awake()
        {
            EventBus.Subscribe("OnSpinButtonPressed", StartSpin);
            EventBus.Subscribe("OnItemSelected", ResetWheel);
        }
        
        private void OnDestroy()
        {
            EventBus.Unsubscribe("OnSpinButtonPressed", StartSpin);
            EventBus.Unsubscribe("OnItemSelected", ResetWheel);
        }

        private void Start()
        {
            RandomizeSlots(wheelSettings.bronzeWheel);
        }
        
        private void StartSpin()
        {
            wheelSpinManager.SpinWheel(this);
            _spinCount++;
        }

        private void ResetWheel()
        {
            var newWheelType = wheelSettings.GetWheelTypeWithSpinCount(_spinCount);
            wheelImageManager.TryUpdateWheelType(newWheelType);
            RandomizeSlots(newWheelType);
            
            if (!newWheelType.isSafeZone)
            {
                PlaceBomb();
            }
        }

        private void RandomizeSlots(WheelType currentWheelType)
        {
            for (var i = 0; i < wheelItems.Count; i++)
            {
                var item = wheelItems[i];
                var randomItemData = allItemData.winnableItems.GetRandomElement();
                var count = currentWheelType.GetRandomRewardCount();
                var itemData = new ItemObjectData(randomItemData, count);
                item.PrepareItem(itemData);
            }
        }

        private void PlaceBomb()
        {
            var randomIndex = Random.Range(0, wheelItems.Count);
            var bombItemObjectData = new ItemObjectData(allItemData.bombItem, 0);
            wheelItems[randomIndex].PrepareItem(bombItemObjectData);
        }
    }
}