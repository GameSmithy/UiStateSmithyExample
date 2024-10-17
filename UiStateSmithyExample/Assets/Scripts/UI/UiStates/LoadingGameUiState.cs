using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace UI.UiStates
{
    public partial class LoadingGameUiState
    {
        private readonly ReactiveProperty<int> progress = new();

        protected override void PrepareData()
        {
            BackgroundUiCanvasIntent.color = Color.black;
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
                await UniTask.Delay(20);
                progress.Value = i;
            }

            MoveToLobbyUiState();
        }
    }
}