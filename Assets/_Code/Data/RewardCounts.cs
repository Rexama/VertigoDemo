using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RewardCounts", order = 1)]
    [Serializable]
    public class RewardCounts : ScriptableObject
    {
        public MinMaxCount bronze;
        public MinMaxCount silver;
        public MinMaxCount golden;
        
        public int GetRandomRewardCount(WheelType wheelType)
        {
            switch (wheelType)
            {
                case WheelType.Bronze:
                    return Random.Range(bronze.min, bronze.max + 1);
                case WheelType.Silver:
                    return Random.Range(silver.min, silver.max + 1);
                case WheelType.Golden:
                    return Random.Range(golden.min, golden.max + 1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(wheelType), wheelType, null);
            }
        }
    }

    [Serializable]
    public struct MinMaxCount
    {
        public int min;
        public int max;
    }

    
}