using _Code.Data;
using _Code.Tools;
using TMPro;
using UnityEngine;

namespace _Code.Item
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemType itemType;
        [SerializeField] private int count;

        private TextMeshProUGUI _textMeshPro;
        private SpriteLoader _spriteLoader;

        private void OnValidate()
        {
            TryCacheComponents();
            UpdateValues();
        }

        private void Awake()
        {
            TryCacheComponents();
            UpdateValues();
        }

        private void TryCacheComponents()
        {
            if (_textMeshPro != null) return;

            _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
            _spriteLoader = GetComponentInChildren<SpriteLoader>();
        }

        private void UpdateValues()
        {
            if (count != 0) _textMeshPro.text = "x" + count;
            else _textMeshPro.text = "";

            _spriteLoader.UpdateSprite(itemType.GetEnumMemberValue());
        }

        public void IncreaseItemCount(int value)
        {
            count += value;
            UpdateValues();
        }

        public void PrepareItem(ItemData itemData)
        {
            itemType = itemData.ItemType;
            count = itemData.Count;
            UpdateValues();
        }

        public ItemData GetItemData()
        {
            return new ItemData(itemType, count);
        }
    }
}