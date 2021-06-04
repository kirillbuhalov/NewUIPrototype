using UnityEngine;

namespace UI
{
    public class BackgroundViewSettings : ViewSettingsBase
    {
        public override string ResourceId { get; set; } = "BackgroundView";
        public Vector4 Color { get; set; }
    }
}