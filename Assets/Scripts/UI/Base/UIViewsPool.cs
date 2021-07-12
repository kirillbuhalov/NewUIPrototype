using System.Collections.Generic;
using UnityEngine;

namespace NewUIPrototype.UI
{
    internal class UIViewsPool : MonoBehaviour
    {
        public static UIViewsPool Instance { get; private set; }

        [SerializeField] private List<ViewBase> views;

        private readonly Dictionary<string, Stack<ViewBase>> inactive = new Dictionary<string, Stack<ViewBase>>();
        private readonly Dictionary<string, ViewBase> cachedPrefabs = new Dictionary<string, ViewBase>();

        private void Awake()
        {
            for (int i = 0; i < views.Count; i++)
            {
                inactive.Add(views[i].name, new Stack<ViewBase>());
                cachedPrefabs.Add(views[i].name, views[i]);
            }

            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public TView Spawn<TView>(string resourceId) where TView : ViewBase
        {
            TView view;

            if (inactive[resourceId].Count > 0)
            {
                view = (TView) inactive[resourceId].Pop();
            }
            else
            {
                var viewPrefab = cachedPrefabs[resourceId];
                view = (TView) Instantiate(viewPrefab);
                view.name = viewPrefab.name;
            }

            return view;
        }

        public TView SpawnInParent<TView>(string resourceId, Transform parentTransform) where TView : ViewBase
        {
            TView view = Spawn<TView>(resourceId);
            view.transform.SetParent(parentTransform);
            return view;
        }

        public void DeSpawn(ViewBase view)
        {
            view.Close();
            inactive[view.name].Push(view);
            view.transform.SetParent(transform);
        }
    }
}