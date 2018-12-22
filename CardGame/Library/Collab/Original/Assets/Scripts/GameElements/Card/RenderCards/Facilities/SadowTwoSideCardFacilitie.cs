using System;
using Card.RenderCards;
using Card.RenderCard.Factorys;

namespace Card.RenderCard.Facilities
{
    class SadowTwoSideCardFacilitie : CardFacilitie
    {
        public override CardRender CreateMagicCard()
        {
            CardFactory factory = new SadowTwoSideCardFactory();
            return new MinionCardRender(factory);
        }

        public override CardRender CreateMinionCard()
        {
            CardFactory factory = new SadowTwoSideCardFactory();
            return new MagicCardRender(factory);
        }
    }
}
