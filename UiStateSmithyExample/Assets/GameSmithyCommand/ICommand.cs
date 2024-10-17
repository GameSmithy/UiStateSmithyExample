using Cysharp.Threading.Tasks;

namespace GameSmithyCommand {
   public interface ICommand {
      public UniTask TryExecuteAsync();
      public UniTask ExecuteAsync();
      public ICommand AddChild(ICommand command);
   }
}