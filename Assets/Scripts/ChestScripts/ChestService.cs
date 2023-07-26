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
        private List<ChestController> chestControllers = new();
        private bool chestUnlockingInProcess;

        [SerializeField] private int numberOfSlots = 4;
        [SerializeField] private ChestScriptableObjectList chestScriptableObjectList;

        private void Start()
        {
            EventService.Instance.OnCreateChest += CreateRandomChest;
        }

        private void CreateRandomChest(Transform chestHolder)
        {
            if (chestControllers.Count == numberOfSlots || chestHolder == null)
                return;
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

        private void OnDestroy()
        {
            EventService.Instance.OnCreateChest -= CreateRandomChest;
        }
    }
}
