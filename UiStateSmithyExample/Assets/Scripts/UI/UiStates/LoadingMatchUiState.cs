using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace UI.UiStates
{
    public partial class LoadingMatchUiState
    {
        private readonly ReactiveProperty<int> progress = new();

        protected override void PrepareData()
        {
            BackgroundUiCanvasIntent.color = Color.blue;
            LoadingUiCanvasIntent.progress = progress;
        }

        protected override void OnShow()
        {
            base.OnShow();
            FakeLoading().Forget();
        }

        private async UniTask FakeLoading()
        {
            progress.Value = 0;

            for (var i = 0; i <= 100; i++) {
                await UniTask.Delay(10);
                progress.Value = i;
            }

            MoveToMatchUiState();
        }
    }
}