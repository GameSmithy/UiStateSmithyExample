using Commands;
using Cysharp.Threading.Tasks;
using UI.UiStates;
using UniDi;

namespace GameStates
{
    public partial class LoadingGameState
    {
        // [Inject]
        // private ChangeUiStateCommand.Factory uiCommandFactory;

        protected override void OnEnter()
        {
            base.OnEnter();
            ShowUi().Forget();
        }

        private async UniTask ShowUi()
        {
            // await uiCommandFactory.Create(UiStateType.None, UiStateType.LoadingGameUiState).ExecuteAsync();
            MoveToMetaGameState();
        }
    }
}