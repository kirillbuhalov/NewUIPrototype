using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    internal class UIViewsPool : MonoBehaviour
    {
        public static UIViewsPool Instance { get; private set; }

        [SerializeField] private List<ViewBase> views;

        private readonly Dictionary<int, Stack<ViewBase>> inactive = new Dictionary<int, Stack<ViewBase>>();

        private void Awake()
        {
            for (int i = 0; i < views.Count; i++)
            {
                inactive.Add(views[i].Guid, new Stack<ViewBase>());
            }

            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public TView Spawn<TView, TViewContext>(TViewContext viewContext) where TView : ViewBase where TViewContext : ViewContextBase
        {
            TView view;

            if (inactive[viewContext.ViewGuid].Count > 0)
            {
                view = (TView) inactive[viewContext.ViewGuid].Pop();
            }
            else
            {
                var viewPrefab = views.First(v => v.Guid == viewContext.ViewGuid);
                view = (TView) Instantiate(viewPrefab);
            }

            return view;
        }

        public TView Spawn<TView, TViewContext>(TViewContext viewContext, Transform parentTransform) where TView : ViewBase where TViewContext : ViewContextBase
        {
            TView view = Spawn<TView, TViewContext>(viewContext);
            view.transform.SetParent(parentTransform);
            return view;
        }

        public void DeSpawn(ViewBase view)
        {
            view.OnClose();
            inactive[view.Guid].Push(view);
            view.gameObject.SetActive(false);
        }
    }
}