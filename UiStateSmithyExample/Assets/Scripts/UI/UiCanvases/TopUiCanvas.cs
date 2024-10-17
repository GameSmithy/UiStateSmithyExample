using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UiCanvases
{
    public partial class TopUiCanvas
    {
        [SerializeField]
        private TMP_Text coinsText;
        [SerializeField]
        private Button coinsButton;

        public Action CoinsPressed;

        private IDisposable coinsSubscription;

        protected override void OnShow()
        {
            base.OnShow();
            coinsSubscription = intent.currencyAmount?.Subscribe(OnCurrencyUpdated);

            coinsButton.onClick.AddListener(OpenShop);
        }

        private void OpenShop()
        {
            CoinsPressed?.Invoke();
        }

        protected override void OnHide()
        {
            base.OnHide();
            coinsSubscription?.Dispose();

            coinsButton.onClick.RemoveListener(OpenShop);
        }

        private void OnCurrencyUpdated(int coins)
        {
            coinsText.text = $"Coins: {coins}";
        }
    }
}