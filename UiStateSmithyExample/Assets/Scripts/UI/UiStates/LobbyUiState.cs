using System;
using Commands;
using Cysharp.Threading.Tasks;
using GameStates;
using UniDi;
using UniRx;

namespace UI.UiStates
{
    public partial class LobbyUiState
    {
        [Inject]
        private ChangeGameStateCommand.Factory gameStateFactory;
        [Inject]
        private Inventory inventory;

        private readonly ReactiveProperty<int> coinsAmount = new();

        private IDisposable coinsSubscription;

        protected override void PrepareData()
        {
            coinsAmount.Value = inventory.Coins.Value;
            TopUiCanvasIntent.currencyAmount = coinsAmount;
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            coinsSubscription = inventory.Coins.Subscribe(value => coinsAmount.Value = value);

            BottomUiCanvas.PlayButtonPressed += OnPlayButtonPressed;
            BottomUiCanvas.SettingsButtonPressed += OnShowSettingsPressed;

            TopUiCanvas.CoinsPressed += OnOpenShopPressed;
        }

        private void OnOpenShopPressed()
        {
            MoveToShopUiState();
        }

        private void OnShowSettingsPressed()
        {
            MoveToSettingsUiState();
        }

        protected override void UnSubscribe()
        {
            base.UnSubscribe();
            coinsSubscription.Dispose();

            BottomUiCanvas.PlayButtonPressed -= OnPlayButtonPressed;
            BottomUiCanvas.SettingsButtonPressed -= OnShowSettingsPressed;

            TopUiCanvas.CoinsPressed -= OnOpenShopPressed;
        }

        private void OnPlayButtonPressed()
        {
            OnPlayButtonPressedAsync().Forget();
        }

        private async UniTask OnPlayButtonPressedAsync()
        {
            await gameStateFactory.Create(GameStateType.MetaGameState, GameStateType.MatchGameState).ExecuteAsync();
            MoveToLoadingMatchUiState();
        }
    }
}