using Commands;
using Cysharp.Threading.Tasks;
using GameStates;
using UI.UiCanvases;
using UI.UiStates;
using UniDi;
using UnityEngine;

namespace DI
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStatesProvider>().AsSingle();
            Container.Bind<Inventory>().AsSingle();
            Container.Bind<CanvasProvider>().AsSingle().NonLazy();
            Container.Bind<UiStateProvider>().AsSingle();

            Container.BindFactory<int, AddCoinsCommand, AddCoinsCommand.Factory>();
            Container.BindFactory<GameStateType, GameStateType, ChangeGameStateCommand, ChangeGameStateCommand.Factory>();
            // Container.BindFactory<UiStateType, UiStateType, ChangeUiStateCommand, ChangeUiStateCommand.Factory>();
        }

        public override void Start()
        {
            WaitAndActivateGame().Forget();
        }

        private async UniTask WaitAndActivateGame()
        {
            await UniTask.DelayFrame(2);
            var factory = Container.Resolve<ChangeGameStateCommand.Factory>();
            var cmd = factory.Create(GameStateType.None, GameStateType.InitGameState);
            await cmd.ExecuteAsync();
            Debug.Log($"{cmd.GetType()} executing finished");
        }
    }
}