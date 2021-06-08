using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NewUIPrototype.UI
{
    internal class UIViewsPool : MonoBehaviour
    {
        private const string CLONE_POSTFIX = "(Clone)";
        public static UIViewsPool Instance { get; private set; }

        [SerializeField] private List<ViewBase> views;

        private readonly Dictionary<string, Stack<ViewBase>> inactive = new Dictionary<string, Stack<ViewBase>>();

        private void Awake()
        {
            for (int i = 0; i < views.Count; i++)
            {
                inactive.Add(views[i].name, new Stack<ViewBase>());
            }

            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public TView GetView<TView>(string resourceId) where TView : ViewBase
        {
            var view = Instance.Spawn<TView>(resourceId);
            return view;
        }

        public TView GetView<TView>(string resourceId, Transform parent) where TView : ViewBase
        {
            var view = Instance.Spawn<TView>(resourceId, parent);
            return view;
        }

        private TView Spawn<TView>(string resourceId) where TView : ViewBase
        {
            TView view;

            if (inactive[resourceId].Count > 0)
            {
                view = (TView) inactive[resourceId].Pop();
            }
            else
            {
                var viewPrefab = views.First(v => v.name == resourceId);
                view = (TView) Instantiate(viewPrefab);
            }

            return view;
        }

        private TView Spawn<TView>(string resourceId, Transform parentTransform) where TView : ViewBase
        {
            TView view = Spawn<TView>(resourceId);
            view.transform.SetParent(parentTransform);
            return view;
        }

        public void DeSpawn(ViewBase view)
        {
            view.Close();
            string id = view.name.Substring(0, view.name.Length - CLONE_POSTFIX.Length);
            inactive[id].Push(view);
            view.transform.SetParent(transform);
        }
    }
}