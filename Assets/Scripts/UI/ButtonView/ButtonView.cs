using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class ButtonView : ViewBase<ButtonViewContext>
    {
        // public static readonly int ComponentGuid = GuidManager.GetNextGuid();
        //
        // public override int Guid => ComponentGuid;
        //
        // [SerializeField] private Button button;
        //
        // public override void Initialize(ButtonViewContext context)
        // {
        //     base.Initialize(context);
        //
        //     SetViewSettings(context.ViewSettings);
        //
        //     ShowNestedViews();
        // }
        //
        // private void SetViewSettings(ButtonViewSettings viewSettings)
        // {
        //     base.SetViewSettings(viewSettings);
        //
        //     button.image.color = viewSettings.Color;
        // }
        //
        // private void ShowNestedViews()
        // {
        //     var labelView = UIViewsPool.Instance.Spawn<TextView>(new TextViewSettings(), transform);
        //     labelView.Setup(Context.LabelViewContext);
        //     AddNestedView(labelView);
        // }
    }
}