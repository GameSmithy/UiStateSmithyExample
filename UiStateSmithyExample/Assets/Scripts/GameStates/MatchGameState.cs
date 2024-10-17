using Commands;
using Cysharp.Threading.Tasks;
using UniDi;

namespace GameStates
{
    public partial class MatchGameState
    {
        [Inject]
        private AddCoinsCommand.Factory addCoinsCommandFactory;

        protected override void OnExit()
        {
            base.OnExit();
            addCoinsCommandFactory.Create(100).ExecuteAsync().Forget();
        }
    }
}