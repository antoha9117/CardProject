using UnityEngine;
using TMPro;

namespace Card.RenderCard.Parts
{
    abstract public class AttributeRender
    {
        public Transform transform { get; protected set; }
        public SpriteRenderer spriteRenderer { get; protected set; }
        public TextMeshPro textMesh { get; protected set; }
    }
}
