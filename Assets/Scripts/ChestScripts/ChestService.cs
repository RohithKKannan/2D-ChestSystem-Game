using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Generics;
using ChestSystem.ScriptableObjects;
using ChestSystem.Events;

namespace ChestSystem.Chest
{
    public enum ChestType
    {
        Common, Rare, Epic, Legendary
    }

    public class ChestService : GenericMonoSingleton<ChestService>
    {
        private List<ChestController> chestControllers = new();

        [SerializeField] private int numberOfSlots = 4;
        [SerializeField] private ChestScriptableObjectList chestScriptableObjectList;
        [SerializeField] private Transform chestContainer;

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

        public void DestroyChest(ChestController chestController)
        {
            chestControllers.Remove(chestController);
            GameObject.Destroy(chestController.chestView.gameObject);
        }

        private void OnDestroy()
        {
            EventService.Instance.OnCreateChest -= CreateRandomChest;
        }
    }
}
