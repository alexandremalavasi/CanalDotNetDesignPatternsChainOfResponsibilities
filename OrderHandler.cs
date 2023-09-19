namespace CanalDotNetDesignPatternsChainOfResponsibilities
{
    public abstract class OrderHandler
    {
        protected OrderHandler _nextHandler;

        public OrderHandler SetNext(OrderHandler handler)
        {
            _nextHandler = handler;

            return handler;
        }

        public abstract void Handle(Order order);
    }

}
