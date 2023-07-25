using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestLockedState : ChestState
    {
        [SerializeField] private GameObject lockedPanel;

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
    }
}
