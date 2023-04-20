using System.Collections.Generic;
using _Code.Buttons;
using _Code.Data;
using _Code.Wheel;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Item
{
    public class StoredItemFactory : MonoBehaviour
    {
        [SerializeField] private GameObject verticalItemPrefab;
        [SerializeField] private GameObject horizontalItemPrefab;
        [SerializeField] private HorizontalLayoutGroup winScreenHorizontalGroup;

        private readonly Dictionary<ItemType, Item> _itemDictionary = new Dictionary<ItemType, Item>();


        private void Awake()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent += AddStoredItems;
            ExitButton.OnExitButtonPressedEvent += CopyWinedItems;
        }

        private void OnDestroy()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent -= AddStoredItems;
            ExitButton.OnExitButtonPressedEvent -= CopyWinedItems;
        }

        private void AddStoredItems(ItemData itemData)
        {
            if (itemData.ItemType != ItemType.C4)
            {
                if (_itemDictionary.ContainsKey(itemData.ItemType))
                {
                    _itemDictionary[itemData.ItemType].IncreaseItemCount(itemData.Count);
                }
                else
                {
                    var item = Instantiate(verticalItemPrefab, transform);
                    item.GetComponent<Item>().PrepareItem(itemData);
                    _itemDictionary.Add(itemData.ItemType, item.GetComponent<Item>());
                }
            }
        }

        private void CopyWinedItems()
        {
            foreach (var item in _itemDictionary)
            {
                var newItem = Instantiate(horizontalItemPrefab, winScreenHorizontalGroup.transform);
                newItem.GetComponent<Item>().PrepareItem(item.Value.GetItemData());
            }
        }
    }
}