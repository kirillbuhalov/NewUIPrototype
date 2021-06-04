using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonViewSettings : ViewSettings
    {
        //public override string ResourceId { get; set; } = "ButtonView";
        public Vector4 Color { get; set; }
        public TextViewSettings LabelViewSettings { get; set; }
    }
}