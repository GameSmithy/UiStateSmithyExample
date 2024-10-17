namespace UI.UiStates
{
    public partial class SettingsUiState
    {

        protected override void Subscribe()
        {
            base.Subscribe();
            SettingsUiCanvas.ExitPressed += OnExitPressed;
        }

        protected override void UnSubscribe()
        {
            base.UnSubscribe();
            SettingsUiCanvas.ExitPressed -= OnExitPressed;
        }

        private void OnExitPressed()
        {
            MoveToLobbyUiState();
        }
    }
}