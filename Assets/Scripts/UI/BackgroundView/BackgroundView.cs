using UI.Styles;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    internal class BackgroundView : ViewBase<BackgroundViewContext>
    {
        [SerializeField] private Image image;

        public override void Open()
        {
            base.Open();

            //todo kirill.buhalov: get style by id from ViewSettings
            var style = StylesManager.BackgroundViewStyle;
            SetStyle(style);
        }

        private void SetStyle(BackgroundViewStyle style)
        {
            image.color = style.Color;
            RectTransform.sizeDelta = style.Size;
        }
    }
}