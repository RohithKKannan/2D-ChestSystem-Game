using UnityEngine;
using ChestSystem.Events;

namespace ChestSystem.Chest
{
    public class ChestLockedState : ChestState
    {
        private GameObject lockedPanel;

        protected override void Awake()
        {
            base.Awake();

            lockedPanel = chestView.GetLockedPanel();
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            lockedPanel.SetActive(true);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            lockedPanel.SetActive(false);
        }

        public override void OnChestClick()
        {
            base.OnChestClick();

            // if no other chest is unlocking, then unlock
            if (!chestView.GetChestUnlockProcess())
                chestView.ChangeChestState(chestView.chestUnlockingState);
            else
                EventService.Instance.InvokeOnErrorAlreadyUnlocking();
        }
    }
}
