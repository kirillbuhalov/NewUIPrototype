using System.Collections.Generic;
using UnityEngine;

namespace NewUIPrototype.UI
{
    public class UIService : MonoBehaviour
    {
        public static UIService Instance { get; private set; }

        [SerializeField] private Transform uiRoot;

        private readonly Stack<ViewBase> navigationStack = new Stack<ViewBase>();

        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public void ShowPopup(PopupViewContext viewContext)
        {
            var viewSettings = ViewSettingsManager.GetPopupViewSettings();
            var view = UIViewsPool.Instance.GetView<PopupView>(viewSettings.ResourceId, uiRoot).Open(viewContext, viewSettings);
            navigationStack.Push(view);
        }

        public void ClosePopupScreen()
        {
            var view = navigationStack.Pop();
            UIViewsPool.Instance.DeSpawn(view);
        }
    }
}