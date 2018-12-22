using Card.RenderCards;

namespace Card.RenderCard.Facilities
{
    abstract class CardFacilitie
    {
        abstract public CardRender CreateMinionCard();
        abstract public CardRender CreateMagicCard();
    }
}
