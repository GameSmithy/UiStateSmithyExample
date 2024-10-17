using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace UI.UiCanvases
{
    public partial class LoadingUiCanvas
    {
        [SerializeField]
        private TMP_Text progressText;

        private IDisposable progressSubscription;

        protected override void OnShow()
        {
            base.OnShow();
            progressSubscription = intent.progress.Subscribe(OnProgressUpdated);
        }

        protected override void OnHide()
        {
            base.OnHide();
            progressSubscription?.Dispose();
        }

        private void OnProgressUpdated(int progress)
        {
            progressText.text = $"{progress}%";
        }
    }
}