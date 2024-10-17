using Commands;
using Cysharp.Threading.Tasks;
using GameStates;
using UniDi;

namespace UI.UiStates
{
    public partial class MatchUiState
    {
        [Inject]
        private ChangeGameStateCommand.Factory gameStateFactory;

        protected override void Subscribe()
        {
            base.Subscribe();
            MatchUiCanvas.ExitPressed += OnExitPressed;
        }

        protected override void UnSubscribe()
        {
            base.UnSubscribe();
            MatchUiCanvas.ExitPressed -= OnExitPressed;
        }

        private void OnExitPressed()
        {
            OnPlayButtonPressedAsync().Forget();
        }

        private async UniTask OnPlayButtonPressedAsync()
        {
            await gameStateFactory.Create(GameStateType.MatchGameState, GameStateType.MetaGameState).ExecuteAsync();
            MoveToLoadingMetaUiState();
        }
    }
}