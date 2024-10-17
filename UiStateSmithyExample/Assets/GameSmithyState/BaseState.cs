using System.Collections.Generic;
using UnityEngine;

namespace GameSmithyState {
    public class BaseState : IState
    {
        protected virtual HashSet<string> AllowedPaths => new();

        public bool IsPathAllowed(string path) {
           return AllowedPaths.Contains(path);
        }

        public void Enter() {
            OnEnter();
        }

        public void Exit() {
            OnExit();
        }

        protected virtual void OnEnter() {
            Debug.Log($"{GetType()} entered");
        }
        
        protected virtual void OnExit() {
            Debug.Log($"{GetType()} exited");
        }
    }
}
