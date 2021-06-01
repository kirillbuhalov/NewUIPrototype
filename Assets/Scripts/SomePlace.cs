using UI;
using UnityEngine;
using UnityEngine.UI;

public class SomePlace : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(ShowPopup);
    }

    public void ShowPopup()
    {
        var popup = new PopupViewContext
        {
            BackgroundViewContext = new BackgroundViewContext
            {
                ViewSettings = new BackgroundViewSettings
                {
                    AnchorMin = new Vector2(0.5f, 0.5f),
                    AnchorMax = new Vector2(0.5f, 0.5f),
                    Pivot = new Vector2(0.5f, 0.5f),
                    SizeDelta = new Vector2(1000, 800),
                    Color = Color.gray,
                }
            },
            TitleViewContext = new TextViewContext
            {
                Label = "PopupTitle",
                ViewSettings = new TextViewSettings
                {
                    AnchorMin = new Vector2(0f, 1f),
                    AnchorMax = new Vector2(1f, 1f),
                    AnchoredPosition = new Vector2(0, -40),
                    Pivot = new Vector2(0.5f, 1f),
                    SizeDelta = new Vector2(0, 100),
                    TextSize = 50,
                    TextColor = Color.white,
                }
            },
            MessageViewContext = new TextViewContext
            {
                Label = "Long long message",
                ViewSettings = new TextViewSettings
                {
                    AnchorMin = new Vector2(0f, 0.5f),
                    AnchorMax = new Vector2(1f, 0.5f),
                    Pivot = new Vector2(0.5f, 0.5f),
                    SizeDelta = new Vector2(0, 100),
                    TextSize = 30,
                    TextColor = Color.white,
                }
            },
            OkButtonViewContext = new ButtonViewContext
            {
                ViewSettings = new ButtonViewSettings
                {
                    AnchorMin = new Vector2(0.5f, 0f),
                    AnchorMax = new Vector2(0.5f, 0f),
                    AnchoredPosition = new Vector2(-40, 120),
                    Pivot = new Vector2(1f, 0.5f),
                    SizeDelta = new Vector2(160, 44),
                    Colors = new ColorBlock
                    {
                        normalColor = Color.green,
                        highlightedColor = Color.green,
                        pressedColor = Color.green,
                        disabledColor = Color.grey,
                        colorMultiplier = 1
                    }
                },
                LabelViewContext = new TextViewContext
                {
                    Label = "Ok",
                    ViewSettings = new TextViewSettings
                    {
                        TextColor = Color.black,
                        TextSize = 25
                    }
                },
            },
            CancelButtonViewContext = new ButtonViewContext
            {
                ViewSettings = new ButtonViewSettings
                {
                    AnchorMin = new Vector2(0.5f, 0f),
                    AnchorMax = new Vector2(0.5f, 0f),
                    AnchoredPosition = new Vector2(40, 120),
                    Pivot = new Vector2(0f, 0.5f),
                    SizeDelta = new Vector2(160, 44),
                    Colors = new ColorBlock
                    {
                        normalColor = Color.red,
                        highlightedColor = Color.red,
                        pressedColor = Color.red,
                        disabledColor = Color.grey,
                        colorMultiplier = 1
                    }
                },
                LabelViewContext = new TextViewContext
                {
                    Label = "Cancel",
                    ViewSettings = new TextViewSettings
                    {
                        TextColor = Color.black,
                        TextSize = 25
                    }
                }
            }
        };

        UIService.Instance.OpenPopupScreen(popup);
    }
}