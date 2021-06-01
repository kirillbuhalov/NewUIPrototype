namespace UI
{
    public class TextViewContext : ViewContextBase
    {
        public override int ViewGuid => TextView.ComponentGuid;

        public TextViewSettings ViewSettings { get; set; }

        public string Label { get; set; }
    }
}