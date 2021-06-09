using System.Collections.Generic;
using NewUIPrototype.UI;
using UnityEngine;
using UnityEngine.UI;

namespace NewUIPrototype
{
    public class SomePlace : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Button button1;

        private bool isOpen;

        private void Start()
        {
            button.onClick.AddListener(ShowPopup);
            button1.onClick.AddListener(ShowCollection);
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

        public void ShowCollection()
        {
            var context = new ContainerViewContext(0)
            {
                Items = new List<CardViewContext>()
                {
                    new CardViewContext(1),
                    new CardViewContext(1),
                    new CardViewContext(1),
                    new CardViewContext(1),
                    new CardViewContext(1),
                    new CardViewContext(1),
                    new CardViewContext(1),
                    new CardViewContext(1),
                    new CardViewContext(1),
                    new CardViewContext(1),
                    new CardViewContext(1),
                }
            };

            UIService.Instance.ShowContainer(context);
        }
    }
}