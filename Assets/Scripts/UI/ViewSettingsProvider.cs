using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace UI
{
    public static class ViewSettingsProvider
    {
        private static string GetViewSettingsJson()
        {
            var viewSettings = new PopupViewSettings
            {
                ResourceId = "PopupView",
                Nested = new Dictionary<int, ViewSettings>
                {
                    {
                        0, new ViewSettings
                        {
                            ResourceId = "BackgroundView",
                            AnchorMin = new Vector2(0.5f, 0.5f),
                            AnchorMax = new Vector2(0.5f, 0.5f),
                            Pivot = new Vector2(0.5f, 0.5f),
                            SizeDelta = new Vector2(1000, 800),
                            // Nested = new Dictionary<int, ViewSettingsBase>
                            // {
                            //     {
                            //         0, new TextViewSettings
                            //         {
                            //             AnchorMin = new Vector2(0f, 1f),
                            //             AnchorMax = new Vector2(1f, 1f),
                            //             AnchoredPosition = new Vector2(0, -40),
                            //             Pivot = new Vector2(0.5f, 1f),
                            //             SizeDelta = new Vector2(0, 100),
                            //             TextSize = 50,
                            //             TextColor = Color.white,
                            //         }
                            //     },
                            //     {
                            //         1, new TextViewSettings
                            //         {
                            //             AnchorMin = new Vector2(0f, 0.5f),
                            //             AnchorMax = new Vector2(1f, 0.5f),
                            //             Pivot = new Vector2(0.5f, 0.5f),
                            //             SizeDelta = new Vector2(0, 100),
                            //             TextSize = 30,
                            //             TextColor = Color.white,
                            //         }
                            //     },
                            //     {
                            //         2, new ButtonViewSettings
                            //         {
                            //             AnchorMin = new Vector2(0.5f, 0f),
                            //             AnchorMax = new Vector2(0.5f, 0f),
                            //             AnchoredPosition = new Vector2(-40, 120),
                            //             Pivot = new Vector2(1f, 0.5f),
                            //             SizeDelta = new Vector2(160, 44),
                            //             Color = Color.green,
                            //             Nested = new Dictionary<int, ViewSettingsBase>
                            //             {
                            //                 {
                            //                     0, new TextViewSettings
                            //                     {
                            //                         TextColor = Color.black,
                            //                         TextSize = 25
                            //                     }
                            //                 }
                            //             }
                            //         }
                            //     },
                            //     {
                            //         3, new ButtonViewSettings
                            //         {
                            //             AnchorMin = new Vector2(0.5f, 0f),
                            //             AnchorMax = new Vector2(0.5f, 0f),
                            //             AnchoredPosition = new Vector2(40, 120),
                            //             Pivot = new Vector2(0f, 0.5f),
                            //             SizeDelta = new Vector2(160, 44),
                            //             Color = Color.red,
                            //             Nested = new Dictionary<int, ViewSettingsBase>
                            //             {
                            //                 {
                            //                     0, new TextViewSettings
                            //                     {
                            //                         TextColor = Color.black,
                            //                         TextSize = 25
                            //                     }
                            //                 }
                            //             }
                            //         }
                            //     }
                            // }
                        }
                    }
                }
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string result = JsonConvert.SerializeObject(viewSettings, settings);
            return result;
        }

        public static PopupViewSettings GetPopupViewSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.DeserializeObject<PopupViewSettings>(GetViewSettingsJson(), settings);
        }
    }
}