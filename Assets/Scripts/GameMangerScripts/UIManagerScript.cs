using UnityEngine;
using ChestSystem.Events;

namespace ChestSystem.UI
{
    public class UIManagerScript : MonoBehaviour
    {
        public void CreateChest()
        {
            EventService.Instance.InvokeOnCreateChest();
        }
    }
}
