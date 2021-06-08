namespace NewUIPrototype.UI
{
    public sealed class ButtonViewContext : ViewContextBase
    {
        public TextViewContext LabelViewContext { get; set; }

        public ButtonViewContext(int sequenceNumber) : base(sequenceNumber)
        {
        }
    }
}