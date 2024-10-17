using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameSmithyCommand {
    public class BaseCommand : ICommand
    {
        private ICommand childCommand;
        
        public virtual UniTask TryExecuteAsync() {
            throw new System.NotImplementedException();
        }
        
        public virtual async UniTask ExecuteAsync() {
            Debug.Log($"{GetType()} executed");
            await OnExecute();
        }

        private UniTask OnExecute() {
            return childCommand?.ExecuteAsync() ?? UniTask.CompletedTask;
        }
        
        public ICommand AddChild(ICommand command) {
            childCommand = command;
            return this;
        }
    }
}
