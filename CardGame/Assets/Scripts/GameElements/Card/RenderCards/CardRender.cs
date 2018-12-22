using Card.RenderCard.Parts;
using UnityEngine;

namespace Card.RenderCards
{
    abstract class CardRender
    {
        //TODO: параметры необходимые для сборки карты

        public BaseObjectRender cardObject { get; protected set; }
        public AttributeRender attack { get; protected set; }
        public ImageRender face { get; protected set; }
        public AttributeRender health { get; protected set; }
        public AttributeRender morale { get; protected set; }
        public AttributeRender price { get; protected set; }
        public ImageRender shift { get; protected set; }

        public abstract void Configure();

        //TODO: методы для дальнейшей работы с объектом
    }
}
