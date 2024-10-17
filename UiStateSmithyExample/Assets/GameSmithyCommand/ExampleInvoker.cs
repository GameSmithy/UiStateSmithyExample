using UnityEngine;

namespace GameSmithyCommand {
    public class ExampleInvoker : MonoBehaviour
    {
        private void Awake() {
            // var command = new ExampleCommand().AddChild(new BaseCommand());
            // command.ExecuteAsync().ContinueWith(_ => Debug.Log($"{command.GetType()} executing finished"));
        }
    }
}
