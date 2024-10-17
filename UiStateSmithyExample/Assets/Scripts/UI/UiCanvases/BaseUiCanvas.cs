using UnityEngine;

namespace UI.UiCanvases
{
    [RequireComponent(typeof(Canvas))]
    public class BaseUiCanvas : MonoBehaviour
    {
        private Canvas canvas;

        protected virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
            canvas = GetComponent<Canvas>();
        }

        public void Show()
        {
            Debug.Log($"Show canvas {GetType()}", this.gameObject);
            OnShow();
        }

        public void Hide()
        {
            Debug.Log($"Hide canvas {GetType()}", gameObject);
            OnHide();
        }

        protected virtual void OnShow()
        {
            canvas.enabled = true;
        }

        protected virtual void OnHide()
        {
            canvas.enabled = false;
        }
    }
}