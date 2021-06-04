using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ViewBase : MonoBehaviour
    {
        private readonly List<ViewBase> nestedViews = new List<ViewBase>();

        private RectTransform rectTransform = null;
        private Dictionary<int, ViewSettings> nestedViewSettings;

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

        public void AddNestedView(ViewBase view)
        {
            nestedViews.Add(view);
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {

            gameObject.SetActive(false);

            for (int i = 0; i < nestedViews.Count ; i++)
            {
                UIViewsPool.Instance.DeSpawn(nestedViews[i]);
            }

            nestedViews.Clear();
            nestedViewSettings = null;
        }

        internal void SetViewSettings(ViewSettings viewSettings)
        {
            NestedViewSettings = viewSettings.Nested;
            RectTransform.anchorMin = viewSettings.AnchorMin;
            RectTransform.anchorMax = viewSettings.AnchorMax;
            RectTransform.pivot = viewSettings.Pivot;
            RectTransform.anchoredPosition = viewSettings.AnchoredPosition;
            //todo kirill.buhalov: need to think about moving that properties to styles (or not)
            RectTransform.sizeDelta = viewSettings.SizeDelta;
            RectTransform.localScale = viewSettings.LocalScale;
            RectTransform.eulerAngles = viewSettings.EulerAngles;

        }

        internal Dictionary<int, ViewSettings> NestedViewSettings
        {
            get => nestedViewSettings;
            private set => nestedViewSettings = value;
        }
    }

    internal class ViewBase<TViewContext> : ViewBase
        where TViewContext : ViewContextBase
    {
        private TViewContext context;

        public TViewContext Context => context;

        internal void SetContext(TViewContext context)
        {
            this.context = context;
        }

        public override void Close()
        {
            base.Close();

            context = null;
        }
    }
}