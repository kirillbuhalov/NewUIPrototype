using UnityEngine;
using UnityEngine.UI;

namespace NewUIPrototype.UI
{
    internal sealed class TextView : ViewBase<TextViewContext>
    {
        [SerializeField] private Text text;

        protected override void Open()
        {
            base.Open();

            text.text = Context.Label;

            SetStyle();
        }

        private void SetStyle()
        {
            var style = StylesManager.Get<TextViewStyle>(ViewSettings.StyleId);
            text.color = style.Color;
            text.fontSize = style.FontSize;
        }
    }
}