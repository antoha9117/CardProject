namespace Cell.StateCell
{
    class StateCellContext
    {
        private IStateCell _currentState;
        public IStateCell setState { set { _currentState = value; } }

        public StateCellContext(IStateCell state)
        {
            _currentState = state;
        }

        public void Fill()
        {
            _currentState.FillCell(this);
        }

        public void Clean()
        {
            _currentState.ClineCell(this);
        }
    }
}
