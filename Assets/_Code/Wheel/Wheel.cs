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

        [HideInInspector] public List<ItemObject> wheelItems;

        private WheelImageManager _wheelImageManager;
        private WheelSpinManager _wheelSpinManager;
        private int _spinCount = 1;

        private void Awake()
        {
            EventBus.Subscribe("OnSpinButtonPressed", OnStartSpin);
            EventBus.Subscribe("OnItemSelected", ResetWheel);
            
            CacheComponents();
        }
        
        private void OnDestroy()
        {
            EventBus.Unsubscribe("OnSpinButtonPressed", OnStartSpin);
            EventBus.Unsubscribe("OnItemSelected", ResetWheel);
        }
        
        private void CacheComponents()
        {
            _wheelImageManager = GetComponent<WheelImageManager>();
            _wheelSpinManager = GetComponent<WheelSpinManager>();
            wheelItems = new List<ItemObject>(GetComponentsInChildren<ItemObject>());
        }

        private void Start()
        {
            RandomizeSlots(wheelSettings.bronzeWheel);
        }
        
        private void OnStartSpin()
        {
            _wheelSpinManager.SpinWheel(this);
            _spinCount++;
        }

        private void ResetWheel()
        {
            var newWheelType = wheelSettings.GetWheelTypeWithSpinCount(_spinCount);
            _wheelImageManager.TryUpdateWheelType(newWheelType);
            RandomizeSlots(newWheelType);
            
            if (!newWheelType.isSafeZone)
            {
                PlaceBomb();
            }
        }

        private void RandomizeSlots(WheelType currentWheelType)
        {
            foreach (var item in wheelItems)
            {
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