using UnityEngine;
using UnityEngine.UI;

namespace NewUIPrototype.UI
{
    internal sealed class BackgroundView : ViewBase<BackgroundViewContext>
    {
        [SerializeField] private Image image;

        protected override void Open()
        {
            base.Open();

            SetStyle();
        }

        private void SetStyle()
        {
            var style = StylesManager.Get<BackgroundViewStyle>(ViewSettings.StyleId);
            image.color = style.Color;
            RectTransform.sizeDelta = style.Size;
        }
    }
}