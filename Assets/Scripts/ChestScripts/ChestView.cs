using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        private ChestController chestController;
        private ChestState currentChestState;

        [SerializeField] private Image imageHolder;
        [SerializeField] private ChestType chestType;
        [SerializeField] private Sprite chestClosedImage;
        [SerializeField] private Sprite chestOpenedImage;

        [Header("State Serialize Fields")]
        [SerializeField] private GameObject lockedPanel;

        [Header("States")]
        [SerializeField] private ChestLockedState chestLockedState;

        private void Start()
        {
            imageHolder.sprite = chestClosedImage;
            ChangeChestState(chestLockedState);
        }

        public void SetChestController(ChestController _chestController)
        {
            chestController = _chestController;
        }

        public GameObject GetLockedPanel()
        {
            return lockedPanel;
        }

        public void ClickedOnChest()
        {
            chestController.OpenChest();
        }

        public void ChangeChestState(ChestState newChestState)
        {
            if (currentChestState != null)
                currentChestState.OnStateExit();

            currentChestState = newChestState;
            currentChestState.OnStateEnter();
        }
    }
}
