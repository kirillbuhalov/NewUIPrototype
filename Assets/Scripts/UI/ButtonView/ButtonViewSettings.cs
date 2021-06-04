using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonViewSettings : ViewSettingsBase
    {
        public override string ResourceId { get; set; } = "ButtonView";
        public Vector4 Color { get; set; }
        public TextViewSettings LabelViewSettings { get; set; }
    }
}