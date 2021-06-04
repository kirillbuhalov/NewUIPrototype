using System;
using UnityEngine;

namespace UI
{
    public class UIService : MonoBehaviour
    {
        public static UIService Instance { get; private set; }

        [SerializeField] private Transform uiRoot;

        private ViewBase popup;

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
            var viewSettings = ViewSettingsProvider.GetPopupViewSettings();
            popup = UIViewsPool.Instance.GetView<PopupView>(viewSettings.ResourceId, uiRoot).Bind(viewContext, viewSettings)
                .AddNested(UIViewsPool.Instance.GetView<BackgroundView>(viewSettings.Nested[0].ResourceId).Bind(viewContext.BackgroundViewContext, viewSettings.Nested[0]));
        }

        public void ClosePopupScreen()
        {
            UIViewsPool.Instance.DeSpawn(popup);
            popup = null;
        }
    }
}