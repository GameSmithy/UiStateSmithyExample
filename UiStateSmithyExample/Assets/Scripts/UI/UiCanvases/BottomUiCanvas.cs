using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UiCanvases
{
    public partial class BottomUiCanvas
    {
        [SerializeField]
        private Button playButton;
        [SerializeField]
        private Button settingsButton;

        public Action PlayButtonPressed;
        public Action SettingsButtonPressed;

        protected override void OnShow()
        {
            base.OnShow();
            playButton.onClick.AddListener(OnPlayButtonPressed);
            settingsButton.onClick.AddListener(OnSettingsButtonPressed);
        }

        private void OnPlayButtonPressed()
        {
            PlayButtonPressed?.Invoke();
        }

        private void OnSettingsButtonPressed()
        {
            SettingsButtonPressed?.Invoke();
        }

        protected override void OnHide()
        {
            base.OnHide();
            playButton.onClick.RemoveListener(OnPlayButtonPressed);
            settingsButton.onClick.RemoveListener(OnSettingsButtonPressed);
        }
    }
}