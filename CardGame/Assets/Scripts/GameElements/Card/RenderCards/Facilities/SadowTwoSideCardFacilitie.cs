using System;
using Card.RenderCards;
using Card.RenderCard.Factorys;

namespace Card.RenderCard.Facilities
{
    class SadowTwoSideCardFacilitie : CardFacilitie
    {
        CardFactory factory = new SadowTwoSideCardFactory();

        public override CardRender CreateMinionCard()
        {
            return new MinionCardRender(factory);
        }

        public override CardRender CreateMagicCard()
        {
            return new MagicCardRender(factory);
        }
    }
}
