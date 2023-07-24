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
            chestView.transform.SetParent(chestContainer);

            chestModel.SetChestController(this);
            chestView.SetChestController(this);
        }

        public void OpenChest()
        {
            ChestService.Instance.DestroyChest(this);
        }
    }
}
