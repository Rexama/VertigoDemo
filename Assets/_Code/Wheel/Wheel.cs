using System;
using System.Collections.Generic;
using _Code.Buttons;
using _Code.Data;
using _Code.Tools;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _Code.Wheel
{
    public class Wheel : MonoBehaviour
    {
        [HideInInspector] public List<Item.Item> items;

        private WheelImageManager _wheelImageManager;
        private WheelSpinManager _wheelSpinManager;
        private RewardCounts _rewardCounts;
        private GameObject _safeZoneIcon;
        private int _spinCount = 1;

        private void Awake()
        {
            SubscribeEvents();
            TryCacheComponents();
        }

        private void Start()
        {
            RandomizeSlots(WheelType.Bronze);
        }

        private void SubscribeEvents()
        {
            SpinButton.OnSpinButtonPressedEvent += OnStartSpin;
            WheelSpinManager.OnWheelSpinCompleteEvent += OnSpinComplete;
        }

        private void OnDisable()
        {
            SpinButton.OnSpinButtonPressedEvent -= OnStartSpin;
            WheelSpinManager.OnWheelSpinCompleteEvent -= OnSpinComplete;
        }

        private void TryCacheComponents()
        {
            if (_wheelImageManager != null) return;

            _rewardCounts = Resources.Load<RewardCounts>("RewardCounts");
            _wheelImageManager = GetComponent<WheelImageManager>();
            _wheelSpinManager = GetComponent<WheelSpinManager>();
            items = new List<Item.Item>(GetComponentsInChildren<Item.Item>());
            _safeZoneIcon = transform.GetChild(3).gameObject;
        }

        private void OnStartSpin()
        {
            _wheelSpinManager.SpinWheel();
            _spinCount++;
        }

        private void OnSpinComplete(ItemData selectedItemData)
        {
            ResetWheel();
        }

        private void ResetWheel()
        {
            if (_spinCount % 30 == 0)
            {
                _wheelImageManager.TryUpdateWheelType(WheelType.Golden);
                RandomizeSlots(WheelType.Golden);
            }
            else if (_spinCount % 5 == 0)
            {
                _wheelImageManager.TryUpdateWheelType(WheelType.Silver);
                RandomizeSlots(WheelType.Silver);
            }
            else
            {
                _wheelImageManager.TryUpdateWheelType(WheelType.Bronze);
                RandomizeSlots(WheelType.Bronze);
                PlaceBomb();
            }

            _safeZoneIcon.SetActive(_spinCount % 5 == 0);
        }

        private void RandomizeSlots(WheelType currentWheelType)
        {
            foreach (var item in items)
            {
                ItemType randomItemType = ExtensionMethods.GetRandomEnum<ItemType>();
                while (randomItemType == ItemType.C4)
                    randomItemType = ExtensionMethods.GetRandomEnum<ItemType>();

                var count = _rewardCounts.GetRandomRewardCount(currentWheelType);
                var itemData = new ItemData(randomItemType, count);
                item.PrepareItem(itemData);
            }
        }

        private void PlaceBomb()
        {
            var randomIndex = Random.Range(0, items.Count);
            ItemData bombItemData = new ItemData(ItemType.C4, 0);
            items[randomIndex].PrepareItem(bombItemData);
        }
    }
}