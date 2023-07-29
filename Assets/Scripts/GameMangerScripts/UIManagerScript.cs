using UnityEngine;
using ChestSystem.Events;

namespace ChestSystem.UI
{
    public class UIManagerScript : MonoBehaviour
    {
        private Transform[] chestHolders;

        [SerializeField] private Transform chestContainer;

        private void Awake()
        {
            chestHolders = new Transform[chestContainer.childCount];
            for (int i = 0; i < chestContainer.childCount; i++)
            {
                chestHolders[i] = chestContainer.GetChild(i);
            }
        }

        public Transform GetChestHolder()
        {
            foreach (Transform item in chestHolders)
            {
                if (item.childCount == 0)
                    return item;
            }
            return null;
        }

        public void CreateChest()
        {
            Transform chestHolder = GetChestHolder();
            EventService.Instance.InvokeOnCreateChest(chestHolder);
        }
    }
}
