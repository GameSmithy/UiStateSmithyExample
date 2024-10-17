using System;
using Commands;
using Cysharp.Threading.Tasks;
using UniDi;
using UniRx;

namespace UI.UiStates
{
    public partial class ShopUiState
    {
        [Inject]
        private AddCoinsCommand.Factory coinsFactory;
        [Inject]
        private Inventory inventory;

        private IDisposable coinsSubscription;
        private readonly ReactiveProperty<int> coinsAmount = new();

        protected override void PrepareData()
        {
            coinsAmount.Value = inventory.Coins.Value;
            TopUiCanvasIntent.currencyAmount = coinsAmount;
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            coinsSubscription = inventory.Coins.Subscribe(value => coinsAmount.Value = value);

            ShopUiCanvas.ExitPressed += OnExitPressed;
            ShopUiCanvas.AddCoins += OnAddCoinsPressed;
        }

        protected override void UnSubscribe()
        {
            base.UnSubscribe();

            coinsSubscription?.Dispose();

            ShopUiCanvas.ExitPressed -= OnExitPressed;
            ShopUiCanvas.AddCoins -= OnAddCoinsPressed;
        }

        private void OnAddCoinsPressed(int value)
        {
            coinsFactory.Create(value).ExecuteAsync().Forget();
        }

        private void OnExitPressed()
        {
            MoveToLobbyUiState();
        }
    }
}