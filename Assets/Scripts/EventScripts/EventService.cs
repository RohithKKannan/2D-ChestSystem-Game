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
    }
}
