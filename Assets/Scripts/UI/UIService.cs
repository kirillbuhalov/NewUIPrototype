using UnityEngine;

namespace UI
{
    public class UIService : MonoBehaviour
    {
        public static UIService Instance { get; private set; }

        [SerializeField] private Transform uiRoot;

        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public void OpenPopupScreen(PopupViewContext popupContext)
        {
            var root = UIViewsPool.Instance.Spawn<PopupView, PopupViewContext>(popupContext, uiRoot);
            root.Initialize(popupContext);
        }


    }
}