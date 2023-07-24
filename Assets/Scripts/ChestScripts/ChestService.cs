using UnityEngine;
using ChestSystem.Generics;
using ChestSystem.ScriptableObjects;

namespace ChestSystem.Chest
{
    public enum ChestType
    {
        Common, Rare, Epic, Legendary
    }

    public class ChestService : GenericSingleton<ChestService>
    {
        [SerializeField] private ChestScriptableObjectList chestScriptableObjectList;

        public void CreateChest(ChestType chestType)
        {
            ChestScriptableObject chestData = chestScriptableObjectList.chests[(int)chestType];
            ChestController newChestController = new ChestController(chestData);
        }
    }
}
