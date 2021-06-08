namespace NewUIPrototype.UI
{
    public abstract class ViewContextBase
    {
        public int SequenceNumber { get; }

        protected ViewContextBase(int sequenceNumber)
        {
            SequenceNumber = sequenceNumber;
        }
    }
}