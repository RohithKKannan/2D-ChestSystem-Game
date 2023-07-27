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

        public void ChestOpened()
        {
            ChestService.Instance.DestroyChest(this);
        }

        public ChestRewards GetChestRewards()
        {
            return chestModel.chestRewards;
        }

        public bool GetChestUnlockProcess()
        {
            return ChestService.Instance.GetChestUnlockProcess();
        }

        public void SetChestUnlockProcess(bool isUnlocking)
        {
            ChestService.Instance.SetChestUnlockProcess(isUnlocking);
        }

        public float GetTimeToOpen()
        {
            return chestModel.timeToOpen;
        }

        public void AddChestToQueue()
        {
            ChestService.Instance.AddChestToQueue(this);
        }

        public bool CheckIfChestAlreadyInQueue()
        {
            return ChestService.Instance.CheckIfChestAlreadyInQueue(this);
        }

        public void ChangeChestStateToUnlocking()
        {
            chestView.ChangeChestState(chestView.chestUnlockingState);
        }
    }
}
