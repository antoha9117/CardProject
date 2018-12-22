using UnityEngine;

namespace Card.RenderCard.Parts
{
    public class EmptyBaseObjectRender : BaseObjectRender
    {
        public EmptyBaseObjectRender(string name = "BaseObject")
        {
            transformObj = new GameObject(name).transform;
        }
    }
}
