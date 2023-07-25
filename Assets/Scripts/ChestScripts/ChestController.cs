using UnityEngine;
using ChestSystem.ScriptableObjects;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        public ChestModel chestModel { get; }
        public ChestView chestView { get; }

        public ChestController(ChestScriptableObject chestData, Transform chestContainer)
        {
            chestModel = new ChestModel(chestData);
            chestView = GameObject.Instantiate<ChestView>(chestData.chestPrefab);
            chestView.transform.position = Vector3.zero;
            chestView.transform.SetParent(chestContainer, false);

            chestModel.SetChestController(this);
            chestView.SetChestController(this);
        }

        public void OpenChest()
        {
            int coinReward = Random.Range(chestModel.minCoins, chestModel.maxCoins + 1);
            int gemReward = Random.Range(chestModel.minGems, chestModel.maxGems + 1);
            ChestService.Instance.AddCurrency(coinReward, gemReward);
            ChestService.Instance.DestroyChest(this);
        }
    }
}
