using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UiCanvases
{
    public partial class MatchUiCanvas
    {
        [SerializeField]
        private Button exitButton;

        public Action ExitPressed;
        
        protected override void OnShow()
        {
            base.OnShow();
            exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        private void OnExitButtonPressed()
        {
            ExitPressed?.Invoke();
        }

        protected override void OnHide()
        {
            base.OnHide();
            exitButton.onClick.RemoveListener(OnExitButtonPressed);
        }
    }
}