using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData", order = 0)]
    public class ItemData : ScriptableObject
    {
        public Sprite itemSprite;
    }
}