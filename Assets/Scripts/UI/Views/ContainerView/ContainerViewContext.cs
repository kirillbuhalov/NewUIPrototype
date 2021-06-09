using System.Collections.Generic;

namespace NewUIPrototype.UI
{
    public class ContainerViewContext<TItemContext> : ViewContextBase where TItemContext : ViewContextBase
    {
        public List<TItemContext> Items { get; set; }

        public ContainerViewContext(int sequenceNumber) : base(sequenceNumber)
        {
        }
    }
}