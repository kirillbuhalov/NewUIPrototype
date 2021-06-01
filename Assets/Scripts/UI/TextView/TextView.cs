using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class TextView : ViewBase<TextViewContext>
    {
        public static readonly int ComponentGuid = GuidManager.GetNextGuid();

        [SerializeField] private Text text;

        public override int Guid => ComponentGuid;

        public override void Initialize(TextViewContext context)
        {
            base.Initialize(context);

            text.text = context.Label;

            SetViewSettings(context.ViewSettings);
        }

        private void SetViewSettings(TextViewSettings viewSettings)
        {
            base.SetViewSettings(viewSettings);

            text.fontSize = viewSettings.TextSize;
            text.color = viewSettings.TextColor;
        }
    }
}