namespace NewUIPrototype.UI
{
    internal sealed class PopupView : ViewBase<PopupViewContext>
    {
        private ButtonView okButtonView;

        protected override void OpenNestedViews()
        {
            base.OpenNestedViews();

            var backgroundViewSettings = ViewSettings.Nested[Context.BackgroundViewContext.SequenceNumber];
            var backgroundView = UIViewsPool.Instance
                .SpawnInParent<BackgroundView>(backgroundViewSettings.ResourceId, transform)
                .Open(Context.BackgroundViewContext, backgroundViewSettings);
            AddNested(backgroundView);

            var titleViewSettings = ViewSettings.Nested[Context.TitleViewContext.SequenceNumber];
            backgroundView.AddNested(UIViewsPool.Instance
                .SpawnInParent<TextView>(titleViewSettings.ResourceId, backgroundView.transform)
                .Open(Context.TitleViewContext, titleViewSettings));

            var messageViewSettings = ViewSettings.Nested[Context.MessageViewContext.SequenceNumber];
            backgroundView.AddNested(UIViewsPool.Instance
                .SpawnInParent<TextView>(messageViewSettings.ResourceId, backgroundView.transform)
                .Open(Context.MessageViewContext, messageViewSettings));

            var okButtonViewSettings = ViewSettings.Nested[Context.OkButtonViewContext.SequenceNumber];
            okButtonView = UIViewsPool.Instance.SpawnInParent<ButtonView>(okButtonViewSettings.ResourceId, backgroundView.transform);
            okButtonView.Open(Context.OkButtonViewContext, okButtonViewSettings);
            backgroundView.AddNested(okButtonView);

            var cancelButtonViewSettings = ViewSettings.Nested[Context.CancelButtonViewContext.SequenceNumber];
            var cancelButtonView = UIViewsPool.Instance
                .SpawnInParent<ButtonView>(cancelButtonViewSettings.ResourceId, backgroundView.transform)
                .Open(Context.CancelButtonViewContext, cancelButtonViewSettings);
            backgroundView.AddNested(cancelButtonView);
        }

        protected override void AddSubscriptions()
        {
            base.AddSubscriptions();

            okButtonView.OnClick += OkClickHandler;
        }

        protected override void RemoveSubscriptions()
        {
            okButtonView.OnClick -= OkClickHandler;

            base.RemoveSubscriptions();
        }

        private void OkClickHandler()
        {
            UIService.Instance.ClosePopupScreen();
        }
    }
}