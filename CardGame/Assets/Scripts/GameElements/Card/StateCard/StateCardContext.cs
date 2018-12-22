namespace Card.StateCard
{
    class StateCardContext
    {
        private IStateCard _currentState;
        public IStateCard setState { set { _currentState = value; } }

        public StateCardContext(IStateCard state)
        {
            _currentState = state;
        }

        public void UsingCard()
        {
            _currentState.UsingCard(this);
        }
    }
}
