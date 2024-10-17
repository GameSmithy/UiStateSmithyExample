using UniRx;

public class Inventory
{
    public readonly ReactiveProperty<int> Coins = new ReactiveProperty<int>(0);

    public void AddCoins(int value)
    {
        Coins.Value += value;
    }
}