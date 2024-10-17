namespace GameStates
{
    public partial class InitGameState
    {
        protected override void OnEnter()
        {
            base.OnEnter();

            MoveToLoadingGameState();
        }
    }
}