namespace _Code.Data
{
    public struct ItemData
    {
        public ItemData(ItemType itemType, int count)
        {
            ItemType = itemType;
            Count = count;
        }
        
        public readonly ItemType ItemType;
        public readonly int Count;
    }
}