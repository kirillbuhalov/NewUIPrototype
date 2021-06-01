namespace UI
{
    internal class PopupView : ViewBase<PopupViewContext>
    {
        public static readonly int ComponentGuid = GuidManager.GetNextGuid();

        public override int Guid => ComponentGuid;

        public override void Initialize(PopupViewContext context)
        {
            base.Initialize(context);

            SetViewSettings(new ViewSettingsBase());

            ShowNestedViews();
        }

        private void ShowNestedViews()
        {
            var backgroundView = UIViewsPool.Instance.Spawn<BackgroundView, BackgroundViewContext>(Context.BackgroundViewContext, transform);
            backgroundView.Initialize(Context.BackgroundViewContext);
            AddNestedView(backgroundView);

            var titleView = UIViewsPool.Instance.Spawn<TextView, TextViewContext>(Context.TitleViewContext, backgroundView.transform);
            titleView.Initialize(Context.TitleViewContext);
            AddNestedView(titleView);

            var messageView = UIViewsPool.Instance.Spawn<TextView, TextViewContext>(Context.MessageViewContext, backgroundView.transform);
            messageView.Initialize(Context.MessageViewContext);
            AddNestedView(messageView);

            var okButtonView = UIViewsPool.Instance.Spawn<ButtonView, ButtonViewContext>(Context.OkButtonViewContext, backgroundView.transform);
            okButtonView.Initialize(Context.OkButtonViewContext);
            AddNestedView(okButtonView);

            var cancelButtonView = UIViewsPool.Instance.Spawn<ButtonView, ButtonViewContext>(Context.CancelButtonViewContext, backgroundView.transform);
            cancelButtonView.Initialize(Context.CancelButtonViewContext);
            AddNestedView(cancelButtonView);
        }
    }
}