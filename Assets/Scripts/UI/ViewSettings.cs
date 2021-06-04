using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class ViewSettings
    {
        public string ResourceId { get; set; } = "EmptyView";
        public string StyleId { get; set; }
        public Vector2 AnchorMin { get; set; } = Vector2.zero;
        public Vector2 AnchorMax { get; set; } = Vector2.one;
        public Vector2 Pivot { get; set; } = new Vector2(0.5f, 0.5f);
        public Vector2 AnchoredPosition { get; set; } = Vector2.zero;
        public Vector2 SizeDelta { get; set; } = Vector2.zero;
        public Vector3 LocalScale { get; set; } = Vector3.one;
        public Vector3 EulerAngles { get; set; } = Vector3.zero;

        //todo kirill.buhalov: dictionary instead of list?
        public Dictionary<int, ViewSettings> Nested { get; set; }

        public TViewSettings GetNested<TViewSettings>(int key) where TViewSettings : ViewSettings
        {
            return (TViewSettings) Nested[key];
        }
    }
}