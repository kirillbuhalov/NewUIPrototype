using UnityEngine;

namespace UI
{
    public class UIService : MonoBehaviour
    {
        public static UIService Instance { get; private set; }

        [SerializeField] private Transform uiRoot;

        private PopupView popup;

        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public void OpenPopupScreen(PopupViewContext popupContext, PopupViewSettings viewSettings)
        {
            popup = UIViewsPool.Instance.Spawn<PopupView>(viewSettings, uiRoot);
            popup.Initialize(popupContext, viewSettings);
        }

        public void ClosePopupScreen()
        {
            UIViewsPool.Instance.DeSpawn(popup);
            popup = null;
        }
    }
}