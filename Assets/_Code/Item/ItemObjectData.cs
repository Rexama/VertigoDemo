namespace Item
{
    public struct ItemObjectData
    {
        public readonly ItemData ItemData;
        public readonly int Count;
        
        public ItemObjectData(ItemData ıtemData, int count)
        {
            ItemData = ıtemData;
            Count = count;
        }
    }
}