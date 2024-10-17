using UnityEngine;
using UnityEngine.UI;

namespace UI.UiCanvases
{
    public partial class BackgroundUiCanvas
    {
        [SerializeField]
        private Image backgroundImage;

        protected override void OnShow()
        {
            base.OnShow();
            backgroundImage.color = intent.color;
        }
    }
}