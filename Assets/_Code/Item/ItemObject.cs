using TMPro;
using Tools;
using UnityEngine;

namespace Item
{
    public class ItemObject : MonoBehaviour
    {
        [SerializeField] private ItemData itemData;
        [SerializeField] private int count;

        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private SpriteLoader spriteLoader;

        private void OnValidate()
        {
            UpdateValues();
        }

        private void Awake()
        {
            UpdateValues();
        }
        
        private void UpdateValues()
        {
            if (count != 0) countText.text = "x" + count;
            else countText.text = "";

            spriteLoader.TryUpdateSprite(itemData.sprite);
        }

        public void IncreaseItemCount(int increaseAmount)
        {
            count += increaseAmount;
            UpdateValues();
        }
        
        
        public void PrepareItem(ItemObjectData newItemData)
        {
            itemData = newItemData.ItemData;
            count = newItemData.Count;
            UpdateValues();
        }

        public ItemObjectData GetItemData()
        {
            return new ItemObjectData(itemData, count);
        }
    }
}