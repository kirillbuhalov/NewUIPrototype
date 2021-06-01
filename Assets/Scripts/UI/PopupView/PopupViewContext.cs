namespace UI
{
    public class PopupViewContext : ViewContextBase
    {
        public override int ViewGuid => PopupView.ComponentGuid;

        public BackgroundViewContext BackgroundViewContext { get; set; }

        public TextViewContext TitleViewContext { get; set; }

        public TextViewContext MessageViewContext { get; set; }

         public ButtonViewContext OkButtonViewContext { get; set; }

         public ButtonViewContext CancelButtonViewContext { get; set; }
    }
}