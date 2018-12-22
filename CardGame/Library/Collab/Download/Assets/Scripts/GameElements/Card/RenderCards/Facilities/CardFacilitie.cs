using Card.RenderCards;

namespace Card.RenderCard.Facilities
{
    public enum CardRenderType
    {
        Minion,
        Magic
    }

    abstract class CardFacilitie
    {
        abstract public CardRender CreateCard(CardRenderType type);


    }
}
