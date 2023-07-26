using UnityEngine;
using ChestSystem.ScriptableObjects;

namespace ChestSystem.Chest
{
    public class ChestModel
    {
        public int minCoins { get; }
        public int maxCoins { get; }
        public int minGems { get; }
        public int maxGems { get; }
        public float timeToOpen { get; }
        public ChestType chestType { get; }

        private ChestController chestController;

        public ChestModel(ChestScriptableObject chestData)
        {
            minCoins = chestData.minCoins;
            maxCoins = chestData.maxCoins;
            minGems = chestData.minGems;
            maxGems = chestData.maxGems;
            chestType = chestData.chestType;
            timeToOpen = chestData.timeToOpen;
        }

        public void SetChestController(ChestController _chestController)
        {
            chestController = _chestController;
        }
    }
}
