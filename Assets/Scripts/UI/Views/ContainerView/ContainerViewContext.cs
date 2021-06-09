using System.Collections.Generic;

namespace NewUIPrototype.UI
{
    public class ContainerViewContext : ViewContextBase
    {
        public List<CardViewContext> Items { get; set; }

        public ContainerViewContext(int sequenceNumber) : base(sequenceNumber)
        {
        }
    }
}