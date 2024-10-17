using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameSmithyCommand {
    public class ExampleCommand : BaseCommand
    {
        public override async UniTask ExecuteAsync() {
            Debug.Log("ExampleCommand was executed");

           await base.ExecuteAsync();
        }
    }
}
