namespace UI.UiCanvases
{
    public partial class CanvasProvider
    {
        public BaseUiCanvas GetCanvas(CanvasType type)
        {
            return canvases[type];
        }
    }
}