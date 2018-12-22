using System;
using Card.RenderCards;
using Card.RenderCard.Factorys;

namespace Card.RenderCard.Facilities
{
    class SadowTwoSideCardFacilitie : CardFacilitie
    {
        public override CardRender CreateCard(CardRenderType type)
        {
            try
            {
                CardFactory factory = new SadowTwoSideCardFactory();

                switch (type)
                {
                    case CardRenderType.Minion:
                        return new MinionCardRender(factory);
                    case CardRenderType.Magic:
                        return new MagicCardRender(factory);
                    default:
                        throw new ArgumentException("SadowTwoSideCardFacilitie: Несуществующий тип карты!");
                }
            }
            catch (ArgumentException ex){throw;}
            catch (Exception ex)
            {
                throw new Exception("SadowTwoSideCardFacilitie: " + ex.Message);
            }
        }
    }
}
