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

        public void InvokeOnCreateChest(Transform chestHolder)
        {
            OnCreateChest?.Invoke(chestHolder);
        }
    }
}
