using System;
using UnityEngine;
using UnityEngine.UI;

namespace NewUIPrototype.UI
{
    internal sealed class ButtonView : ViewBase<ButtonViewContext>
    {
        [SerializeField] private Button button;

        public event Action OnClick;

        protected override void Open()
        {
            base.Open();

            SetStyle();
        }

        private void SetStyle()
        {
            var style = StylesManager.Get<ButtonViewStyle>(ViewSettings.StyleId);
            button.image.color = style.Color;
            RectTransform.sizeDelta = style.Size;
        }

        protected override void OpenNestedViews()
        {
            base.OpenNestedViews();

            var labelViewSettings = ViewSettings.Nested[Context.LabelViewContext.SequenceNumber];
            AddNested(UIViewsPool.Instance
                .SpawnInParent<TextView>(labelViewSettings.ResourceId, transform)
                .Open(Context.LabelViewContext, labelViewSettings));

        }

        protected override void AddSubscriptions()
        {
            base.AddSubscriptions();

            button.onClick.AddListener(ClickHandler);
        }

        protected override void RemoveSubscriptions()
        {
            button.onClick.RemoveListener(ClickHandler);

            base.RemoveSubscriptions();
        }

        private void ClickHandler()
        {
            OnClick?.Invoke();
        }
    }
}