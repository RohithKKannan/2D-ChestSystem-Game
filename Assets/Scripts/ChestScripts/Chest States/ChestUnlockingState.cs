using UnityEngine;
using TMPro;

namespace ChestSystem.Chest
{
    public class ChestUnlockingState : ChestState
    {
        [SerializeField] private float timeToUnlock;
        private bool timerIsRunning;

        private GameObject unlockingPanel;
        private TMP_Text timerText;

        protected override void Awake()
        {
            base.Awake();

            unlockingPanel = chestView.GetUnlockingPanel();
            timerText = chestView.GetTimerText();
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            timeToUnlock = chestView.GetTimeToOpenChest();
            timerIsRunning = true;
            unlockingPanel.SetActive(true);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            unlockingPanel.SetActive(false);
        }

        private void DisplayTime(float time)
        {
            time += 1;
            float hours = Mathf.FloorToInt(time / 3600);
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }

        public override void Tick()
        {
            base.Tick();

            if (!timerIsRunning)
                return;

            if (timeToUnlock > 0)
            {
                timeToUnlock -= Time.deltaTime;
                DisplayTime(timeToUnlock);
            }
            else
            {
                timeToUnlock = 0;
                timerIsRunning = false;
            }
        }
    }
}
