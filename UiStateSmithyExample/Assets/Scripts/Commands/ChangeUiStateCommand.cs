using Cysharp.Threading.Tasks;
using GameSmithyCommand;
using GameSmithyState;
using UI.UiStates;
using UniDi;
using UnityEngine;

namespace Commands
{
    public class ChangeUiStateCommand : BaseCommand
    {
        private readonly IState nextState;
        private readonly IState currentState;

        [Inject]
        public ChangeUiStateCommand(UiStateType currentUiStateType, UiStateType nextUiStateType,
            UiStateProvider uiStateProvider)
        {
            nextState = uiStateProvider.GetState(nextUiStateType);
            currentState = currentUiStateType == UiStateType.None ? null : uiStateProvider.GetState(currentUiStateType);

            Debug.Log($"change state {currentUiStateType} nextState {nextState}");
        }

        public override async UniTask ExecuteAsync()
        {
            currentState?.Exit();
            nextState.Enter();
            await base.ExecuteAsync();
        }

        public class Factory : PlaceholderFactory<UiStateType, UiStateType, ChangeUiStateCommand>
        {
        }
    }
}