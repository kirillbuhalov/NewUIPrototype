namespace NewUIPrototype.UI
{
    public sealed class TextViewContext : ViewContextBase
    {
        public string Label { get; set; }

        public TextViewContext(int sequenceNumber) : base(sequenceNumber)
        {
        }
    }
}