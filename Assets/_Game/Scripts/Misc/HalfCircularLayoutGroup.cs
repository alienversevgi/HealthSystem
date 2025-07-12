namespace Misc
{
    using UnityEngine;
    using UnityEngine.UI;

#if UNITY_EDITOR
    using UnityEditor;
#endif

    [AddComponentMenu("Layout/Half Circular Layout Group")]
    public class HalfCircularLayoutGroup : LayoutGroup
    {
        [Range(0f, 360f)] public float arcAngle = 180f;
        public float radius = 100f;
        public bool clockwise = true;

        public override void CalculateLayoutInputHorizontal() { base.CalculateLayoutInputHorizontal(); }
        public override void CalculateLayoutInputVertical() { }

        public override void SetLayoutHorizontal() { SetChildrenAlongArc(); }
        public override void SetLayoutVertical() { SetChildrenAlongArc(); }

        private void SetChildrenAlongArc()
        {
            int childCount = rectChildren.Count;
            if (childCount == 0) return;

            float angleStep = arcAngle / (childCount - 1);
            float startAngle = clockwise ? 0 : 180;

            for (int i = 0; i < childCount; i++)
            {
                float angle = startAngle + (clockwise ? -angleStep * i : angleStep * i);
                float rad = angle * Mathf.Deg2Rad;

                Vector2 pos = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

                RectTransform child = rectChildren[i];
                SetChildAlongAxis(child, 0, pos.x - (child.rect.width * child.pivot.x));
                SetChildAlongAxis(child, 1, pos.y - (child.rect.height * child.pivot.y));
            }
        }
    }

}