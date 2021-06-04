using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class ViewSettingsBase
    {
        //todo kirill.buhalov: need to think about better way to identify the settings instance
        public int Id { get; set; }

        public virtual string ResourceId { get; set; } = "EmptyView";
        public Vector2 AnchorMin { get; set; } = Vector2.zero;
        public Vector2 AnchorMax { get; set; } = Vector2.one;
        public Vector2 Pivot { get; set; } = new Vector2(0.5f, 0.5f);
        public Vector2 AnchoredPosition { get; set; } = Vector2.zero;
        public Vector2 SizeDelta { get; set; } = Vector2.zero;
        public Vector3 LocalScale { get; set; } = Vector3.one;
        public Vector3 EulerAngles { get; set; } = Vector3.zero;

        //todo kirill.buhalov: dictionary instead of list?
        public List<ViewSettingsBase> Nested { get; set; }

        // public string ResourceId  = "EmptyView";
        // public Vector2 AnchorMin  = Vector2.zero;
        // public Vector2 AnchorMax = Vector2.one;
        // public Vector2 Pivot = new Vector2(0.5f, 0.5f);
        // public Vector2 AnchoredPosition = Vector2.zero;
        // public Vector2 SizeDelta = Vector2.zero;
        // public Vector3 LocalScale = Vector3.one;
        // public Vector3 Rotation = Vector3.zero;


    }
}