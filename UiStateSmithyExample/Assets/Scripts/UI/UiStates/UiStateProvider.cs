using GameSmithyState;

namespace UI.UiStates
{
    public partial class UiStateProvider
    {
        public IState GetState(UiStateType type)
        {
            return states[type];
        }
    }
}
