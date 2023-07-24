using UnityEngine;
using ChestSystem.Chest;

namespace ChestSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ScriptableObjects/NewChest")]
    public class ChestScriptableObject : ScriptableObject
    {
        public ChestType chestType;

        [Header("Coins")]
        public int minCoins;
        public int maxCoins;

        [Header("Gems")]
        public int minGems;
        public int maxGems;

        [Header("Timer")]
        public int timeToOpen;

        public ChestView chestPrefab;
    }
}

