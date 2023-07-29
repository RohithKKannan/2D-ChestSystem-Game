using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        private ChestController chestController;

        [SerializeField] private Image imageHolder;
        [SerializeField] private ChestType chestType;
        [SerializeField] private Sprite chestClosedImage;
        [SerializeField] private Sprite chestOpenedImage;

        private void Start()
        {
            imageHolder.sprite = chestClosedImage;
        }

        public void SetChestController(ChestController _chestController)
        {
            chestController = _chestController;
        }

        public void ClickedOnChest()
        {
            chestController.OpenChest();
        }
    }
}
