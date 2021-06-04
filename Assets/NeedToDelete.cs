using System.Collections.Generic;
using Newtonsoft.Json;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class NeedToDelete : MonoBehaviour
{
    [ContextMenu("GoGoGo")]
    public void SuperMethod()
    {
        var rectTransform = this.transform as RectTransform;

        var viewSettings = new ViewSettingsBase
        {
            Nested = new List<ViewSettingsBase>
            {
                new BackgroundViewSettings
                {
                    AnchorMin = new Vector2(0.5f, 0.5f),
                    AnchorMax = new Vector2(0.5f, 0.5f),
                    Pivot = new Vector2(0.5f, 0.5f),
                    SizeDelta = new Vector2(1000, 800),
                    Color = Color.gray,
                    Nested = new List<ViewSettingsBase>
                    {
                        new ButtonViewSettings
                        {
                            AnchorMin = new Vector2(0.5f, 0f),
                            AnchorMax = new Vector2(0.5f, 0f),
                            AnchoredPosition = new Vector2(-40, 120),
                            Pivot = new Vector2(1f, 0.5f),
                            SizeDelta = new Vector2(160, 44),
                            Color = Color.green,
                            Nested = new List<ViewSettingsBase>
                            {
                                new TextViewSettings
                                {
                                    TextColor = Color.black,
                                    TextSize = 25
                                }
                            }
                        },
                        new ButtonViewSettings
                        {
                            AnchorMin = new Vector2(0.5f, 0f),
                            AnchorMax = new Vector2(0.5f, 0f),
                            AnchoredPosition = new Vector2(40, 120),
                            Pivot = new Vector2(0f, 0.5f),
                            SizeDelta = new Vector2(160, 44),
                            Color = Color.red,
                            Nested = new List<ViewSettingsBase>
                            {
                                new TextViewSettings
                                {
                                    TextColor = Color.black,
                                    TextSize = 25
                                }
                            }
                        }
                    }
                },
                new TextViewSettings
                {
                    AnchorMin = new Vector2(0f, 1f),
                    AnchorMax = new Vector2(1f, 1f),
                    AnchoredPosition = new Vector2(0, -40),
                    Pivot = new Vector2(0.5f, 1f),
                    SizeDelta = new Vector2(0, 100),
                    TextSize = 50,
                    TextColor = Color.white,
                },
                new TextViewSettings
                {
                    AnchorMin = new Vector2(0f, 0.5f),
                    AnchorMax = new Vector2(1f, 0.5f),
                    Pivot = new Vector2(0.5f, 0.5f),
                    SizeDelta = new Vector2(0, 100),
                    TextSize = 30,
                    TextColor = Color.white,
                }
            }
        };

        var result = JsonConvert.SerializeObject(viewSettings);
    }
}