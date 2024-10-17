using GameSmithyState;

namespace GameStates
{
    public partial class GameStatesProvider
    {
        public IState GetState(GameStateType type)
        {
            return states[type];
        }
    }
}