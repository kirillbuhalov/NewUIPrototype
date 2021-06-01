using UnityEngine;

namespace UI
{
    public class ViewSettingsBase
    {
        public Vector2 AnchorMin { get; set; } = Vector2.zero;
        public Vector2 AnchorMax { get; set; } = Vector2.one;
        public Vector2 Pivot { get; set; } = new Vector2(0.5f, 0.5f);
        public Vector2 AnchoredPosition { get; set; } = Vector2.zero;
        public Vector2 SizeDelta { get; set; } = Vector2.zero;
        public Vector3 LocalScale { get; set; } = Vector3.one;
        public Quaternion Rotation { get; set; } = Quaternion.identity;


    }
}