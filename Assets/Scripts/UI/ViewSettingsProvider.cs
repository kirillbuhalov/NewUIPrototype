using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace UI
{
    public class ViewSettingsProvider
    {
        private static string GetViewSettingsJson()
        {
            var viewSettings = new PopupViewSettings
            {
                Nested = new List<ViewSettingsBase>
                {
                    new BackgroundViewSettings
                    {
                        Id = 0,
                        AnchorMin = new Vector2(0.5f, 0.5f),
                        AnchorMax = new Vector2(0.5f, 0.5f),
                        Pivot = new Vector2(0.5f, 0.5f),
                        SizeDelta = new Vector2(1000, 800),
                        Color = Color.gray,
                        Nested = new List<ViewSettingsBase>
                        {
                            new TextViewSettings
                            {
                                Id = 1,
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
                                Id = 2,
                                AnchorMin = new Vector2(0f, 0.5f),
                                AnchorMax = new Vector2(1f, 0.5f),
                                Pivot = new Vector2(0.5f, 0.5f),
                                SizeDelta = new Vector2(0, 100),
                                TextSize = 30,
                                TextColor = Color.white,
                            },
                            new ButtonViewSettings
                            {
                                Id = 3,
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
                                        Id = 5,
                                        TextColor = Color.black,
                                        TextSize = 25
                                    }
                                }
                            },
                            new ButtonViewSettings
                            {
                                Id = 4,
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
                                        Id =  6,
                                        TextColor = Color.black,
                                        TextSize = 25
                                    }
                                }
                            }
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

        public static ViewSettingsBase GetViewSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.DeserializeObject<ViewSettingsBase>(GetViewSettingsJson(), settings);
        }
    }
}