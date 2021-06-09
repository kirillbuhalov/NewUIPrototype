using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace NewUIPrototype.UI
{
    public static class ViewSettingsManager
    {
        private static string GetPopupViewSettingsJson()
        {
            var viewSettings = new ViewSettings
            {
                ResourceId = "PopupView",
                Nested = new Dictionary<int, ViewSettings>
                {
                    {
                        1, new ViewSettings
                        {
                            ResourceId = "BackgroundView",
                            StyleId = "RedBackgroundViewStyle",
                            AnchorMin = new Vector2(0.5f, 0.5f),
                            AnchorMax = new Vector2(0.5f, 0.5f),
                            Pivot = new Vector2(0.5f, 0.5f),
                            SizeDelta = new Vector2(1000, 800),
                        }
                    },
                    {
                        2, new ViewSettings
                        {
                            ResourceId = "TextView",
                            StyleId = "MediumWhiteTextViewStyle",
                            AnchorMin = new Vector2(0f, 1f),
                            AnchorMax = new Vector2(1f, 1f),
                            AnchoredPosition = new Vector2(0, -40),
                            Pivot = new Vector2(0.5f, 1f),
                            SizeDelta = new Vector2(0, 100),
                        }
                    },
                    {
                        3, new ViewSettings
                        {
                            ResourceId = "TextView",
                            StyleId = "MediumWhiteTextViewStyle",
                            AnchorMin = new Vector2(0f, 0.5f),
                            AnchorMax = new Vector2(1f, 0.5f),
                            Pivot = new Vector2(0.5f, 0.5f),
                            SizeDelta = new Vector2(0, 100),
                        }
                    },
                    {
                        4, new ViewSettings
                        {
                            ResourceId = "ButtonView",
                            StyleId = "GreenButtonViewStyle",
                            AnchorMin = new Vector2(0.5f, 0f),
                            AnchorMax = new Vector2(0.5f, 0f),
                            AnchoredPosition = new Vector2(-40, 120),
                            Pivot = new Vector2(1f, 0.5f),
                            SizeDelta = new Vector2(160, 44),
                            Nested = new Dictionary<int, ViewSettings>
                            {
                                {
                                    5, new ViewSettings
                                    {
                                        ResourceId = "TextView",
                                        StyleId = "SmallBlueTextViewStyle"
                                    }
                                }
                            }
                        }
                    },
                    {
                        6, new ViewSettings
                        {
                            ResourceId = "ButtonView",
                            StyleId = "RedButtonViewStyle",
                            AnchorMin = new Vector2(0.5f, 0f),
                            AnchorMax = new Vector2(0.5f, 0f),
                            AnchoredPosition = new Vector2(40, 120),
                            Pivot = new Vector2(0f, 0.5f),
                            SizeDelta = new Vector2(160, 44),
                            Nested = new Dictionary<int, ViewSettings>
                            {
                                {
                                    7, new ViewSettings
                                    {
                                        ResourceId = "TextView",
                                        StyleId = "SmallBlueTextViewStyle"
                                    }
                                }
                            }
                        }
                    },
                },
            };


            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string result = JsonConvert.SerializeObject(viewSettings, settings);
            return result;
        }

        private static string GetContainerViewSettingsJson()
        {
            var viewSettings = new ViewSettings
            {
                ResourceId = "ContainerView",
                AnchorMin = new Vector2(0.5f, 0.5f),
                AnchorMax = new Vector2(0.5f, 0.5f),
                Pivot = new Vector2(0.5f, 0.5f),
                SizeDelta = new Vector2(1000, 800),
                Nested = new Dictionary<int, ViewSettings>
                {
                    {
                        1, new ViewSettings
                        {
                            ResourceId = "CardView",
                        }
                    }
                },
            };


            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string result = JsonConvert.SerializeObject(viewSettings, settings);
            return result;
        }

        public static ViewSettings GetPopupViewSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.DeserializeObject<ViewSettings>(GetPopupViewSettingsJson(), settings);
        }

        public static ViewSettings GetContainerViewSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.DeserializeObject<ViewSettings>(GetContainerViewSettingsJson(), settings);
        }
    }
}