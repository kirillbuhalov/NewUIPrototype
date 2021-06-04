using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class BackgroundView : ViewBase<BackgroundViewContext>
    {
        public static readonly int ComponentGuid = GuidManager.GetNextGuid();

        public override int Guid => ComponentGuid;

        [SerializeField] private Image image;

        public void Initialize(BackgroundViewContext context, BackgroundViewSettings viewSettings)
        {
            base.Initialize(context);

            SetViewSettings(viewSettings);
        }

        private void SetViewSettings(BackgroundViewSettings viewSettings)
        {
            base.SetViewSettings(viewSettings);

            image.color = viewSettings.Color;
        }
    }
}