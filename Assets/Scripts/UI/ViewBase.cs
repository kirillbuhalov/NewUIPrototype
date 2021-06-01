using System;
using UnityEngine;

namespace UI
{
    internal class ViewBase : MonoBehaviour
    {

        private RectTransform rectTransform = null;

        public virtual int Guid => throw new NotImplementedException();

        public RectTransform RectTransform
        {
            get
            {
                if (rectTransform == null)
                {
                    rectTransform = (RectTransform) gameObject.transform;
                }

                return rectTransform;
            }
        }

        public virtual void OnOpen()
        {
        }

        public virtual void OnClose()
        {
        }

        protected void SetViewSettings(ViewSettingsBase viewSettings)
        {
            RectTransform.anchorMin = viewSettings.AnchorMin;
            RectTransform.anchorMax = viewSettings.AnchorMax;
            RectTransform.pivot = viewSettings.Pivot;
            RectTransform.anchoredPosition = viewSettings.AnchoredPosition;
            RectTransform.sizeDelta = viewSettings.SizeDelta;
            RectTransform.localScale = viewSettings.LocalScale;
            RectTransform.rotation = viewSettings.Rotation;
        }
    }

    internal class ViewBase<TViewContext> : ViewBase where TViewContext : ViewContextBase
    {
        private TViewContext context;

        public TViewContext Context => context;

        public virtual void Initialize(TViewContext context)
        {
            this.context = context;
        }

        public override void OnClose()
        {
            base.OnClose();

            context = null;
        }
    }
}