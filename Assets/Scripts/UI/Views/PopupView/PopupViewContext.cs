namespace NewUIPrototype.UI
{
    public sealed class PopupViewContext : ViewContextBase
    {
        public BackgroundViewContext BackgroundViewContext { get; set; }

        public TextViewContext TitleViewContext { get; set; }

        public TextViewContext MessageViewContext { get; set; }

         public ButtonViewContext OkButtonViewContext { get; set; }

         public ButtonViewContext CancelButtonViewContext { get; set; }

         public PopupViewContext(int sequenceNumber) : base(sequenceNumber)
         {
         }
    }
}