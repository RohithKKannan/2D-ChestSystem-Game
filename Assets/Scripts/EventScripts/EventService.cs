using UnityEngine;
using System;

namespace ChestSystem.Events
{
    public class EventService
    {
        private static EventService instance = null;
        public static EventService Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventService();

                return instance;
            }
        }

        public event Action<Transform> OnCreateChest;
        public event Action<int> OnUpdateCoinCount;
        public event Action<int> OnUpdateGemCount;
        public event Action<int, string> OnCheckConfirmUnlock;
        public event Action<int> OnCheckConfirmGemsUnlock;
        public event Action OnConfirmUnlock;
        public event Action OnDenyUnlock;
        public event Action OnInsufficientGems;
        public event Action<int, int> OnRewardReceived;
        public event Action OnRewardAccepted;
        public event Action OnErrorAlreadyUnlocking;
        public event Action OnUnlockWithTimer;
        public event Action OnUnlockWithGems;
        public event Action OnSlotsAreFull;
        public event Action OnOpenNextChestInQueue;
        public event Action OnQueueContainsChest;
        public event Action OnChestQueueFull;
        public event Action OnChestQueueEmpty;

        public void InvokeOnCreateChest(Transform chestHolder)
        {
            OnCreateChest?.Invoke(chestHolder);
        }

        public void InvokeOnUpdateCoinCount(int coinCount)
        {
            OnUpdateCoinCount?.Invoke(coinCount);
        }

        public void InvokeOnUpdateGemCount(int gemCount)
        {
            OnUpdateGemCount?.Invoke(gemCount);
        }

        public void InvokeOnCheckConfirmUnlock(int gemCount, string time)
        {
            OnCheckConfirmUnlock?.Invoke(gemCount, time);
        }

        public void InvokeOnCheckConfirmGemsUnlock(int gemCount)
        {
            OnCheckConfirmGemsUnlock?.Invoke(gemCount);
        }

        public void InvokeOnConfirmUnlock()
        {
            OnConfirmUnlock?.Invoke();
        }

        public void InvokeOnDenyUnlock()
        {
            OnDenyUnlock?.Invoke();
        }

        public void InvokeOnInsufficientGems()
        {
            OnInsufficientGems?.Invoke();
        }

        public void InvokeOnRewardReceived(int coinCount, int gemCount)
        {
            OnRewardReceived?.Invoke(coinCount, gemCount);
        }

        public void InvokeOnRewardAccepted()
        {
            OnRewardAccepted?.Invoke();
        }

        public void InvokeOnErrorAlreadyUnlocking()
        {
            OnErrorAlreadyUnlocking?.Invoke();
        }

        public void InvokeOnUnlockWithTimer()
        {
            OnUnlockWithTimer?.Invoke();
        }

        public void InvokeOnUnlockWithGems()
        {
            OnUnlockWithGems?.Invoke();
        }

        public void InvokeOnSlotsAreFull()
        {
            OnSlotsAreFull?.Invoke();
        }

        public void InvokeOnOpenNextChestInQueue()
        {
            OnOpenNextChestInQueue?.Invoke();
        }

        public void InvokeOnQueueContainsChest()
        {
            OnQueueContainsChest?.Invoke();
        }

        public void InvokeOnChestQueueFull()
        {
            OnChestQueueFull?.Invoke();
        }

        public void InvokeOnChestQueueEmpty()
        {
            OnChestQueueEmpty?.Invoke();
        }
    }
}
