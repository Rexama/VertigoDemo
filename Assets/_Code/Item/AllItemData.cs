using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "AllItems", menuName = "Data/AllItems", order = 0)]
    public class AllItemData : ScriptableObject
    {
        public ItemData[] winnableItems;
        
        public ItemData bombItem;
    }
}