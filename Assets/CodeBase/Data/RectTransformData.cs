using System;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class RectTransformData
    {
        public Vector2 AnchoredPosition;
        public Vector2 SizeDelta;
        public Vector2 AnchorMin;
        public Vector2 AnchorMax;
        public Vector2 Pivot;

        public RectTransformData(RectTransform rectTransform)
        {
            AnchoredPosition = rectTransform.anchoredPosition;
            SizeDelta = rectTransform.sizeDelta;
            AnchorMin = rectTransform.anchorMin;
            AnchorMax = rectTransform.anchorMax;
            Pivot = rectTransform.pivot;
        }

        public void ApplyTo(RectTransform rectTransform)
        {
            rectTransform.anchorMin = AnchorMin;
            rectTransform.anchorMax = AnchorMax;
            rectTransform.pivot = Pivot;
            rectTransform.sizeDelta = SizeDelta;
            rectTransform.anchoredPosition = AnchoredPosition;
        }
    }
}