using UnityEngine;

namespace _Code.Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Colors", order = 1)]
    public class CountColors : ScriptableObject
    {
        public Color bronzeCounterColor;
        public Color silverCounterColor;
        public Color goldenCounterColor;
    }
}