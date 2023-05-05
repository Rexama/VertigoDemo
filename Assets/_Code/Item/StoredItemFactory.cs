using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Wheel;
using EventBus = Tools.EventBus;

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
            EventBus.Subscribe("OnExitButtonPressed", CopyStoredItems);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe("OnExitButtonPressed", CopyStoredItems);
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

        private void CopyStoredItems()
        {
            for (var i = 0; i < _itemDictionary.Count; i++)
            {
                var newItem = Instantiate(horizontalItemPrefab, winScreenHorizontalGroup.transform);
                var itemData = _itemDictionary.ElementAt(i).Value.GetItemObjectData();
                newItem.GetComponent<ItemObject>().PrepareItem(itemData);
            }
        }
    }
}