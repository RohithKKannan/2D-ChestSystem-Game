using UnityEngine;
using ChestSystem.Events;

namespace ChestSystem.Chest
{
    public class ChestOpenedState : ChestState
    {
        private int coinReward;
        private int gemReward;
        private GameObject chestOpenedPanel;

        protected override void Awake()
        {
            base.Awake();

            chestOpenedPanel = chestView.GetOpenedPanel();
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            chestOpenedPanel.SetActive(true);
        }

        public override void OnChestClick()
        {
            base.OnChestClick();

            ChestRewards chestRewards = chestView.GetChestRewardsFromController();
            coinReward = Random.Range(chestRewards.minCoins, chestRewards.maxCoins + 1);
            gemReward = Random.Range(chestRewards.minGems, chestRewards.maxGems + 1);

            EventService.Instance.InvokeOnRewardReceived(coinReward, gemReward);
            EventService.Instance.OnRewardAccepted += CollectRewards;
        }

        private void CollectRewards()
        {
            ChestService.Instance.AddCurrency(coinReward, gemReward);

            EventService.Instance.OnRewardAccepted -= OnStateExit;
            EventService.Instance.OnRewardAccepted -= CollectRewards;

            chestView.ChestCollected();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}
