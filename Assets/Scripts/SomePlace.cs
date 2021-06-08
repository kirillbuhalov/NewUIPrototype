using NewUIPrototype.UI;
using UnityEngine;
using UnityEngine.UI;

namespace NewUIPrototype
{
    public class SomePlace : MonoBehaviour
    {
        [SerializeField] private Button button;

        private bool isOpen;

        private void Start()
        {
            button.onClick.AddListener(ShowPopup);
        }

        public void ShowPopup()
        {
            var popup = new PopupViewContext(0)
            {
                BackgroundViewContext = new BackgroundViewContext(1),
                TitleViewContext = new TextViewContext(2)
                {
                    Label = "PopupTitle"
                },
                MessageViewContext = new TextViewContext(3)
                {
                    Label = "Long long message"
                },
                OkButtonViewContext = new ButtonViewContext(4)
                {
                    LabelViewContext = new TextViewContext(5)
                    {
                        Label = "Ok"
                    },
                },
                CancelButtonViewContext = new ButtonViewContext(6)
                {
                    LabelViewContext = new TextViewContext(7)
                    {
                        Label = "Cancel"
                    }
                }
            };

            UIService.Instance.ShowPopup(popup);
        }
    }
}