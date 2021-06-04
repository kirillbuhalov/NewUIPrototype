using UI;
using UnityEngine;
using UnityEngine.UI;

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
        if (isOpen)
        {
            UIService.Instance.ClosePopupScreen();
            isOpen = false;
            return;
        }

        var viewSettings = ViewSettingsProvider.GetViewSettings();

        var popup = new PopupViewContext
        {
            BackgroundViewContext = new BackgroundViewContext(),
            TitleViewContext = new TextViewContext
            {
                Label = "PopupTitle"
            },
            MessageViewContext = new TextViewContext
            {
                Label = "Long long message"
            },
            OkButtonViewContext = new ButtonViewContext
            {
                LabelViewContext = new TextViewContext
                {
                    Label = "Ok"
                },
            },
            CancelButtonViewContext = new ButtonViewContext
            {
                LabelViewContext = new TextViewContext
                {
                    Label = "Cancel"
                }
            }
        };

        UIService.Instance.OpenPopupScreen(popup, viewSettings);
        isOpen = true;
    }
}