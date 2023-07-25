using UnityEngine;
using ChestSystem.Generics;
using ChestSystem.Events;

namespace ChestSystem.Currency
{
    public class CurrencyService : GenericMonoSingleton<CurrencyService>
    {
        private int coins;
        private int gems;

        private void Start()
        {
            coins = 0;
            gems = 0;
            EventService.Instance.InvokeOnUpdateCoinCount(coins);
            EventService.Instance.InvokeOnUpdateGemCount(gems);
        }

        public void AddCoins(int coinCount)
        {
            coins += coinCount;
            EventService.Instance.InvokeOnUpdateCoinCount(coins);
        }

        public bool RemoveCoins(int coinCount)
        {
            if (coins - coinCount < 0)
                return false;

            coins -= coinCount;
            EventService.Instance.InvokeOnUpdateCoinCount(coins);

            return true;
        }

        public void AddGems(int gemCount)
        {
            gems += gemCount;
            EventService.Instance.InvokeOnUpdateGemCount(gems);
        }

        public bool RemoveGems(int gemCount)
        {
            if (gems - gemCount < 0)
                return false;

            gems -= gemCount;
            EventService.Instance.InvokeOnUpdateGemCount(gems);

            return true;
        }
    }
}
