using Card.RenderCard.Parts;
using UnityEngine;

namespace Card.RenderCard.Factorys
{
    public abstract class CardFactory
    {
        public abstract BaseObjectRender CreateBase(string name);
        public abstract ImageRender CreateShirt(Transform parent);
        public abstract ImageRender CreateFace(Transform parent);
        public abstract AttributeRender CreateHealth(Transform parent);
        public abstract AttributeRender CreateAttack(Transform parent);
        public abstract AttributeRender CretePrice(Transform parent);
        public abstract AttributeRender CreateMorale(Transform parent);
    }
}