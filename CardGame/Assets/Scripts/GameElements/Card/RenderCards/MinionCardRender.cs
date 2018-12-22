using Card.RenderCard.Factorys;

namespace Card.RenderCards
{
    class MinionCardRender : CardRender
    {
        CardFactory _factory;

        public MinionCardRender(CardFactory factory)
        {
            //TODO: переопределить базовые параметры
            _factory = factory;
        }

        public override void Configure()
        {
            cardObject = _factory.CreateBase("MinionCardRender");

            attack = _factory.CreateAttack(cardObject.transformObj);
            face = _factory.CreateFace(cardObject.transformObj);
            health = _factory.CreateHealth(cardObject.transformObj);
            morale = _factory.CreateMorale(cardObject.transformObj);
            price = _factory.CretePrice(cardObject.transformObj);
            shift = _factory.CreateShirt(cardObject.transformObj);
        }
    }
}
