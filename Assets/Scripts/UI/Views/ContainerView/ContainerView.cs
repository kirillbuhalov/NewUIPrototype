using UnityEngine;

namespace NewUIPrototype.UI
{
    internal class CardContainerView : ContainerView<CardView, CardViewContext>
    {
    }

    internal class ContainerView<TItemView, TItemViewContext> : ViewBase<ContainerViewContext<TItemViewContext>> where TItemViewContext : ViewContextBase where TItemView : ViewBase<TItemViewContext>
    {
        [SerializeField] private Transform contentRoot;

        private ContainerViewStyle style;

        protected override void Open()
        {
            base.Open();

            style = StylesManager.Get<ContainerViewStyle>(ViewSettings.StyleId);
        }

        protected override void OpenNestedViews()
        {
            base.OpenNestedViews();

            for (int i = 0; i < Context.Items.Count; i++)
            {
                var itemContext = Context.Items[i];
                var itemViewSettings = ViewSettings.Nested[itemContext.SequenceNumber];

                //based on container style we can adjust view settings. For example:
                var alignment = new Vector2(0, 1);
                var itemSize = new Vector2(150, 0);
                int spacing = 5;

                itemViewSettings.AnchorMax = alignment;
                itemViewSettings.SizeDelta = new Vector2(itemSize.x * i + spacing, itemSize.y);
                itemViewSettings.Pivot = new Vector2(0, 0.5f);
                var view = UIViewsPool.Instance
                    .GetView<TItemView>(itemViewSettings.ResourceId, contentRoot)
                    .Open(itemContext, itemViewSettings);
                AddNested(view);
            }
        }
    }
}