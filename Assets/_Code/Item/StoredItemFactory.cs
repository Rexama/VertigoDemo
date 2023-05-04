using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.UI;
using Wheel;

namespace Item
{
    public class StoredItemFactory : MonoBehaviour
    {
        [SerializeField] private GameObject verticalItemPrefab;
        [SerializeField] private GameObject horizontalItemPrefab;
        [SerializeField] private HorizontalLayoutGroup winScreenHorizontalGroup;

        private readonly Dictionary<ItemData, ItemObject> _itemDictionary = new Dictionary<ItemData, ItemObject>();


        private void Awake()
        {
            EventBus.Subscribe("OnExitButtonPressed", CopyWinedItems);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe("OnExitButtonPressed", CopyWinedItems);
        }

        public void AddStoredItems(ItemObjectData itemObjectData)
        {
            if (_itemDictionary.ContainsKey(itemObjectData.ItemData))
            {
                _itemDictionary[itemObjectData.ItemData].IncreaseItemCount(itemObjectData.Count);
            }
            else
            {
                var itemGameObject = Instantiate(verticalItemPrefab, transform);
                var itemObject = itemGameObject.GetComponent<ItemObject>();
                itemObject.PrepareItem(itemObjectData);
                _itemDictionary.Add(itemObjectData.ItemData, itemObject);
            }
        }

        private void CopyWinedItems()
        {
            foreach (var item in _itemDictionary)
            {
                var newItem = Instantiate(horizontalItemPrefab, winScreenHorizontalGroup.transform);
                newItem.GetComponent<ItemObject>().PrepareItem(item.Value.GetItemData());
            }
        }
    }
}