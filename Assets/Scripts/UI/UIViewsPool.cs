using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    internal class UIViewsPool : MonoBehaviour
    {
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

        public TView Spawn<TView>(ViewSettingsBase viewSettings) where TView : ViewBase
        {
            TView view;

            if (inactive[viewSettings.ResourceId].Count > 0)
            {
                view = (TView) inactive[viewSettings.ResourceId].Pop();
            }
            else
            {
                var viewPrefab = views.First(v => v.name == viewSettings.ResourceId);
                view = (TView) Instantiate(viewPrefab);
            }

            return view;
        }

        public TView Spawn<TView>(ViewSettingsBase viewSettings, Transform parentTransform) where TView : ViewBase
        {
            TView view = Spawn<TView>(viewSettings);
            view.transform.SetParent(parentTransform);
            view.gameObject.SetActive(true);
            //todo kirill.buhalov: need to think about better place to this callback
            view.OnOpen();
            return view;
        }

        public void DeSpawn(ViewBase view)
        {
            view.OnClose();
            inactive[view.name].Push(view);
            view.gameObject.SetActive(false);
            view.transform.SetParent(transform);
        }
    }
}