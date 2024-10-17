using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UiCanvases
{
    public partial class ShopUiCanvas
    {
        [SerializeField]
        private Button addCoinsButton;
        [SerializeField]
        private Button exitButton;

        public Action<int> AddCoins;
        public Action ExitPressed;

        protected override void OnShow()
        {
            base.OnShow();
            addCoinsButton.onClick.AddListener(OnAddCoinsPressed);
            exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        private void OnExitButtonPressed()
        {
            ExitPressed?.Invoke();
        }

        private void OnAddCoinsPressed()
        {
            AddCoins?.Invoke(150);
        }

        protected override void OnHide()
        {
            base.OnHide();
            addCoinsButton.onClick.RemoveListener(OnAddCoinsPressed);
            exitButton.onClick.RemoveListener(OnExitButtonPressed);
        }
    }
}