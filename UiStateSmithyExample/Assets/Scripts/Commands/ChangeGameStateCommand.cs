using Cysharp.Threading.Tasks;
using GameSmithyCommand;
using GameSmithyState;
using GameStates;
using UniDi;
using UnityEngine;

namespace Commands
{
    public class ChangeGameStateCommand : BaseCommand
    {
        private readonly IState nextState;
        private readonly IState currentState;

        [Inject]
        public ChangeGameStateCommand(GameStateType currentGameStateType, GameStateType nextGameStateType,
            GameStatesProvider gameStatesProvider)
        {
            nextState = gameStatesProvider.GetState(nextGameStateType);
            currentState = currentGameStateType == GameStateType.None
                ? null
                : gameStatesProvider.GetState(currentGameStateType);

            Debug.Log($"change state {currentGameStateType} nextState {nextState}");
        }

        public override async UniTask ExecuteAsync()
        {
            currentState?.Exit();
            nextState.Enter();
            await base.ExecuteAsync();
        }

        public class Factory : PlaceholderFactory<GameStateType, GameStateType, ChangeGameStateCommand>
        {
        }
    }
}