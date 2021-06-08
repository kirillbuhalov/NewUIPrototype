using System.Collections.Generic;
using UnityEngine;

namespace NewUIPrototype.UI
{
    public static class StylesManager
    {
        private static readonly Dictionary<string, object> styles = new Dictionary<string, object>
        {
            {
                "RedBackgroundViewStyle", new BackgroundViewStyle
                {
                    Size = new Vector2(1000, 800),
                    Color = new Vector4(1, 0, 0, 0.5f),
                }
            },
            {
                "MediumWhiteTextViewStyle", new TextViewStyle
                {
                    FontSize = 36,
                    Color = Color.white,
                }
            },
            {
                "SmallBlueTextViewStyle", new TextViewStyle
                {
                    FontSize = 25,
                    Color = Color.blue,
                }
            },
            {
                "GreenButtonViewStyle", new ButtonViewStyle
                {
                    Size = new Vector2(160, 50),
                    Color = Color.green,
                }
            },
            {
                "RedButtonViewStyle", new ButtonViewStyle
                {
                    Size = new Vector2(160, 50),
                    Color = Color.red,
                }
            },
        };

        public static TStyle Get<TStyle>(string id)
        {
            return (TStyle) styles[id];
        }
    }
}