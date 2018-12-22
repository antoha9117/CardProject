using System;
using Card.RenderCards;
using Card.RenderCard.Factorys;

namespace Card.RenderCard.Facilities
{
    class UICardFacilitie : CardFacilitie
    {
        public override CardRender CreateMagicCard()
        {
            CardFactory factory = new UICardFactory();
            return new MinionCardRender(factory);
        }

        public override CardRender CreateMinionCard()
        {
            CardFactory factory = new UICardFactory();
            return new MagicCardRender(factory);
        }
    }
}
