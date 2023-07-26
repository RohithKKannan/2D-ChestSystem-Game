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
        public event Action<int> OnCheckConfirmUnlock;
        public event Action OnConfirmUnlock;
        public event Action OnDenyUnlock;
        public event Action OnInsufficientGems;
        public event Action<int, int> OnRewardReceived;
        public event Action OnRewardAccepted;
        public event Action OnErrorAlreadyUnlocking;

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

        public void InvokeOnCheckConfirmUnlock(int gemCount)
        {
            OnCheckConfirmUnlock?.Invoke(gemCount);
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
    }
}
