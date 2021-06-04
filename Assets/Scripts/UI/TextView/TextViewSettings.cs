using UnityEngine;

namespace UI
{
    public class TextViewSettings : ViewSettingsBase
    {
        public override string ResourceId { get; set; } = "TextView";
        public int TextSize { get; set; }

        public Vector4 TextColor { get; set; }
    }
}