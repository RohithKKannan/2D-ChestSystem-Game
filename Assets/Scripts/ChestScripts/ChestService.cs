using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Generics;
using ChestSystem.ScriptableObjects;
using ChestSystem.Events;
using ChestSystem.Currency;

namespace ChestSystem.Chest
{
    public enum ChestType
    {
        Common, Rare, Epic, Legendary
    }

    public class ChestService : GenericMonoSingleton<ChestService>
    {
        private Queue<ChestController> chestQueue = new();
        private List<ChestController> chestControllers = new();
        private bool chestUnlockingInProcess;

        [SerializeField] private int numberOfSlots = 4;
        [SerializeField] private int queueLength = 2;
        [SerializeField] private ChestScriptableObjectList chestScriptableObjectList;

        private void Start()
        {
            EventService.Instance.OnCreateChest += CreateRandomChest;
            EventService.Instance.OnOpenNextChestInQueue += OpenNextChestInQueue;
        }

        private void CreateRandomChest(Transform chestHolder)
        {
            if (chestControllers.Count == numberOfSlots || chestHolder == null)
            {
                EventService.Instance.InvokeOnSlotsAreFull();
                return;
            }
            CreateChest((ChestType)Random.Range(0, chestScriptableObjectList.chests.Length), chestHolder);
        }

        public void CreateChest(ChestType chestType, Transform chestHolder)
        {
            ChestScriptableObject chestData = chestScriptableObjectList.chests[(int)chestType];
            ChestController newChestController = new ChestController(chestData, chestHolder);
            chestControllers.Add(newChestController);
        }

        public void AddCurrency(int coinCount, int gemCount)
        {
            CurrencyService.Instance.AddCoins(coinCount);
            CurrencyService.Instance.AddGems(gemCount);
        }

        public void DestroyChest(ChestController chestController)
        {
            chestControllers.Remove(chestController);
            GameObject.Destroy(chestController.chestView.gameObject);
        }

        public bool GetChestUnlockProcess()
        {
            return chestUnlockingInProcess;
        }

        public void SetChestUnlockProcess(bool isUnlocking)
        {
            chestUnlockingInProcess = isUnlocking;
        }

        public void AddChestToQueue(ChestController chestController)
        {
            if (chestQueue.Count < queueLength)
                chestQueue.Enqueue(chestController);
            else
                EventService.Instance.InvokeOnChestQueueFull();
        }

        public bool CheckIfChestAlreadyInQueue(ChestController chestController)
        {
            return chestQueue.Contains(chestController);
        }

        public void OpenNextChestInQueue()
        {
            Debug.Log("Chest Queue count : " + chestQueue.Count);

            if (chestQueue.Count == 0)
                return;

            ChestController chestController = chestQueue.Dequeue();
            chestController.ChangeChestStateToUnlocking();
        }

        private void OnDestroy()
        {
            EventService.Instance.OnCreateChest -= CreateRandomChest;
            EventService.Instance.OnOpenNextChestInQueue -= OpenNextChestInQueue;
        }
    }
}
