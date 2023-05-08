using TMPro;
using Tools;
using UnityEngine;

namespace Item
{
    public class ItemObject : MonoBehaviour
    {
        [SerializeField] private ItemData itemData;
        [SerializeField] private int itemCount;

        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private SpriteLoader spriteLoader;

        private void OnValidate()
        {
            UpdateValues();
        }
        
        private void UpdateValues()
        {
            UpdateCountText();
            spriteLoader.TryUpdateSprite(itemData.itemSprite);
        }


        public void IncreaseItemCount(int increaseAmount)
        {
            itemCount += increaseAmount;
            UpdateValues();
        }

        private void UpdateCountText()
        {
            if (itemCount != 0) countText.text = "x" + itemCount;
            else countText.text = "";
        }
        
        
        public void PrepareItem(ItemObjectData newItemData)
        {
            itemData = newItemData.ItemData;
            itemCount = newItemData.Count;
            UpdateValues();
        }

        public ItemObjectData GetItemObjectData()
        {
            return new ItemObjectData(itemData, itemCount);
        }
    }
}