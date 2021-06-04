namespace UI
{
    public static class ViewBindingExtension
    {
        internal static ViewBase Bind<TContext>(this ViewBase<TContext> view, TContext context, ViewSettings viewSettings) where TContext : ViewContextBase
        {
            view.SetContext(context);
            view.SetViewSettings(viewSettings);
            view.Open();
            return view;
        }

        internal static ViewBase AddNested(this ViewBase parent, ViewBase child)
        {
            child.transform.SetParent(parent.transform);
            parent.AddNestedView(child);
            return parent;
        }
    }
}