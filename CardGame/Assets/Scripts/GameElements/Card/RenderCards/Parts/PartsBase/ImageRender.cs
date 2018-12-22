using UnityEngine;

namespace Card.RenderCard.Parts
{
    abstract public class ImageRender
    {
        public Transform transform { get; protected set; }
        public SpriteRenderer spriteRenderer { get; protected set; }
    }
}