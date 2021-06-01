namespace UI
{
    public class ButtonViewContext : ViewContextBase
    {
        public override int ViewGuid => ButtonView.ComponentGuid;

        public TextViewContext LabelViewContext { get; set; }

        public ButtonViewSettings ViewSettings { get; set; }
    }
}