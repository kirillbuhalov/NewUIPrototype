using UnityEngine;

namespace NewUIPrototype.UI
{
    internal class ContainerView : ViewBase<ContainerViewContext>
    {
        [SerializeField] private Transform contentRoot;

        private ContainerViewStyle style;

        protected override void Open()
        {
            base.Open();

            //style = StylesManager.Get<ContainerViewStyle>(ViewSettings.StyleId);
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
                itemViewSettings.SizeDelta = itemSize;
                itemViewSettings.AnchoredPosition = new Vector2((itemSize.x + spacing) * i, 0);
                itemViewSettings.Pivot = new Vector2(0, 0.5f);

                var view = UIViewsPool.Instance
                    .SpawnInParent<CardView>(itemViewSettings.ResourceId, contentRoot)
                    .Open(itemContext, itemViewSettings);
                AddNested(view);
            }
        }
    }
}