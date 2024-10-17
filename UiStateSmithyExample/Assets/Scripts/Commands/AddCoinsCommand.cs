using Cysharp.Threading.Tasks;
using GameSmithyCommand;
using UniDi;

namespace Commands
{
    public class AddCoinsCommand : BaseCommand
    {
        private readonly Inventory inventory;
        private readonly int coinsToAdd;

        [Inject]
        public AddCoinsCommand(int coinsToAdd, Inventory inventory)
        {
            this.inventory = inventory;
            this.coinsToAdd = coinsToAdd;
        }

        public override async UniTask ExecuteAsync()
        {
            inventory.AddCoins(coinsToAdd);
            await base.ExecuteAsync();
        }

        public class Factory : PlaceholderFactory<int, AddCoinsCommand>
        {
        }
    }
}