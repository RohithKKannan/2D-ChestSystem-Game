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

        public event Action OnCreateChest;

        public void InvokeOnCreateChest()
        {
            OnCreateChest?.Invoke();
        }
    }
}
