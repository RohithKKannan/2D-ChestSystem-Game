using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        [SerializeField] private GameObject unlockingPanel;
        [SerializeField] private TMP_Text timerText;

        [Header("States")]
        public ChestLockedState chestLockedState;
        public ChestUnlockingState chestUnlockingState;

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

        public GameObject GetUnlockingPanel()
        {
            return unlockingPanel;
        }

        public TMP_Text GetTimerText()
        {
            return timerText;
        }

        public float GetTimeToOpenChest()
        {
            return chestController.GetTimeToOpen();
        }

        public void ClickedOnChest()
        {
            currentChestState.OnChestClick();
        }

        public void ChangeChestState(ChestState newChestState)
        {
            if (currentChestState != null)
                currentChestState.OnStateExit();

            currentChestState = newChestState;
            currentChestState.OnStateEnter();
        }

        private void Update()
        {
            currentChestState.Tick();
        }
    }
}
