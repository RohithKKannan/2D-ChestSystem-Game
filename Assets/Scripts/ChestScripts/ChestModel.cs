using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestModel : MonoBehaviour
    {
        public int minCoins { get; }
        public int maxCoins { get; }
        public int minGems { get; }
        public int maxGems { get; }
        public int timeToOpen { get; }
        public ChestType chestType { get; }

        private ChestController chestController;

        public ChestModel()
        {

        }

        public void SetChestController(ChestController _chestController)
        {
            chestController = _chestController;
        }
    }
}
