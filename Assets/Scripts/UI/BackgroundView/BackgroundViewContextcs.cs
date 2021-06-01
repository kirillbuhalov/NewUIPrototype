namespace UI
{
    public class BackgroundViewContext : ViewContextBase
    {
        public override int ViewGuid => BackgroundView.ComponentGuid;

        public BackgroundViewSettings ViewSettings { get; set; }
    }
}