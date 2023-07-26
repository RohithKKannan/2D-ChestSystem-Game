using System.Collections;
using UnityEngine;
using TMPro;
using ChestSystem.Events;

namespace ChestSystem.UI
{
    public class UIManagerScript : MonoBehaviour
    {
        private Transform[] chestHolders;
        private Coroutine textFadeCoroutine;
        private bool coroutineRunning;

        [Header("Currency")]
        [SerializeField] private TMP_Text coinCount;
        [SerializeField] private TMP_Text gemCount;

        [Header("Chest Container")]
        [SerializeField] private Transform chestContainer;

        [Header("Confirm Unlock")]
        [SerializeField] private GameObject confirmUnlockPanel;
        [SerializeField] private TMP_Text gemText;

        [Header("Insufficient Gems Popup")]
        [SerializeField] private GameObject insufficientGemsPopup;

        [Header("Rewards Popup")]
        [SerializeField] private GameObject rewardsPopup;
        [SerializeField] private TMP_Text coinRewardCount;
        [SerializeField] private TMP_Text gemRewardCount;

        [Header("Errors")]
        [SerializeField] private CanvasGroup errorChestAlreadyOpening;

        private void Awake()
        {
            chestHolders = new Transform[chestContainer.childCount];
            for (int i = 0; i < chestContainer.childCount; i++)
            {
                chestHolders[i] = chestContainer.GetChild(i);
            }

            EventService.Instance.OnUpdateCoinCount += UpdateCoinCount;
            EventService.Instance.OnUpdateGemCount += UpdateGemCount;
            EventService.Instance.OnCheckConfirmUnlock += UnlockChestPopUp;
            EventService.Instance.OnInsufficientGems += InsufficientGems;
            EventService.Instance.OnRewardReceived += EnableRewardsPopup;
            EventService.Instance.OnErrorAlreadyUnlocking += ChestAlreadyBeingOpened;
        }

        public Transform GetChestHolder()
        {
            foreach (Transform item in chestHolders)
            {
                if (item.childCount == 0)
                    return item;
            }
            return null;
        }

        public void CreateChest()
        {
            Transform chestHolder = GetChestHolder();
            EventService.Instance.InvokeOnCreateChest(chestHolder);
        }

        public void UpdateCoinCount(int coinCountValue)
        {
            coinCount.text = coinCountValue.ToString();
        }

        public void UpdateGemCount(int gemCountValue)
        {
            gemCount.text = gemCountValue.ToString();
        }

        public void UnlockChestPopUp(int gemCount)
        {
            gemText.text = "Unlock chest with " + gemCount + " gems?";
            confirmUnlockPanel.SetActive(true);
        }

        public void CloseUnlockChestPopUp()
        {
            confirmUnlockPanel.SetActive(false);
        }

        public void InsufficientGems()
        {
            insufficientGemsPopup.SetActive(true);
        }

        public void CloseInsufficientGems()
        {
            insufficientGemsPopup.SetActive(false);
        }

        public void ConfirmUnlock()
        {
            CloseUnlockChestPopUp();
            EventService.Instance.InvokeOnConfirmUnlock();
        }

        public void DenyUnlock()
        {
            CloseUnlockChestPopUp();
            EventService.Instance.InvokeOnDenyUnlock();
        }

        public void EnableRewardsPopup(int coinCount, int gemCount)
        {
            coinRewardCount.text = coinCount.ToString();
            gemRewardCount.text = gemCount.ToString();
            rewardsPopup.SetActive(true);
        }

        public void AcceptRewards()
        {
            rewardsPopup.SetActive(false);
            EventService.Instance.InvokeOnRewardAccepted();
        }

        public void ChestAlreadyBeingOpened()
        {
            if (coroutineRunning)
            {
                StopCoroutine(textFadeCoroutine);
                coroutineRunning = false;
            }
            textFadeCoroutine = StartCoroutine(BeginFade());
        }

        private IEnumerator BeginFade()
        {
            errorChestAlreadyOpening.alpha = 1;
            coroutineRunning = true;
            yield return new WaitForSeconds(2f);

            while (errorChestAlreadyOpening.alpha > 0)
            {
                errorChestAlreadyOpening.alpha -= 0.5f * Time.deltaTime;
                yield return null;
            }
            errorChestAlreadyOpening.alpha = 0;
            coroutineRunning = false;
        }

        private void OnDestroy()
        {
            EventService.Instance.OnUpdateCoinCount -= UpdateCoinCount;
            EventService.Instance.OnUpdateGemCount -= UpdateGemCount;
            EventService.Instance.OnCheckConfirmUnlock -= UnlockChestPopUp;
            EventService.Instance.OnInsufficientGems -= InsufficientGems;
            EventService.Instance.OnRewardReceived -= EnableRewardsPopup;
            EventService.Instance.OnErrorAlreadyUnlocking -= ChestAlreadyBeingOpened;
        }
    }
}
