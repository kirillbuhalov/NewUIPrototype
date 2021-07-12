using System.Collections.Generic;
using UnityEngine;

namespace NewUIPrototype.UI
{
    public class ViewBase : MonoBehaviour
    {
        [SerializeField] private Canvas viewRoot;

        private readonly List<ViewBase> nestedViews = new List<ViewBase>();

        private RectTransform rectTransform = null;
        private ViewSettings viewSettings;

        internal ViewSettings ViewSettings
        {
            get => viewSettings;
            private set => viewSettings = value;
        }

        public RectTransform CachedRectTransform
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

        protected virtual void AddSubscriptions()
        {
        }

        protected virtual void RemoveSubscriptions()
        {
        }

        protected virtual void OpenNestedViews()
        {
        }

        internal void AddNested(ViewBase view)
        {
            nestedViews.Add(view);
        }

        protected virtual void Open()
        {
            viewRoot.enabled = true;

            OpenNestedViews();

            AddSubscriptions();
        }

        public virtual void Close()
        {
            RemoveSubscriptions();

            viewRoot.enabled = false;

            for (int i = 0; i < nestedViews.Count ; i++)
            {
                UIViewsPool.Instance.DeSpawn(nestedViews[i]);
            }

            nestedViews.Clear();
            viewSettings = null;
        }

        internal void SetViewSettings(ViewSettings viewSettings)
        {
            ViewSettings = viewSettings;
            CachedRectTransform.anchorMin = viewSettings.AnchorMin;
            CachedRectTransform.anchorMax = viewSettings.AnchorMax;
            CachedRectTransform.pivot = viewSettings.Pivot;
            CachedRectTransform.anchoredPosition = viewSettings.AnchoredPosition;
            //todo kirill.buhalov: need to think about moving that properties to styles (or not)
            CachedRectTransform.sizeDelta = viewSettings.SizeDelta;
            CachedRectTransform.localScale = viewSettings.LocalScale;
            CachedRectTransform.eulerAngles = viewSettings.EulerAngles;

        }
    }

    internal class ViewBase<TViewContext> : ViewBase
        where TViewContext : ViewContextBase
    {
        private TViewContext context;

        public TViewContext Context => context;

        internal ViewBase Open(TViewContext context, ViewSettings viewSettings)
        {
            this.context = context;
            SetViewSettings(viewSettings);
            Open();
            return this;
        }


        public override void Close()
        {
            base.Close();

            context = null;
        }
    }
}