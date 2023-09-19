namespace CanalDotNetDesignPatternsChainOfResponsibilities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                Items = new List<string> { "item1", "item2" },
                TotalAmount = 200.0M,
                PromoCode = "CANALDOTNET10",
                UserLocation = "BR"
            };

            OrderHandler validationHandler = new ValidationHandler();
            OrderHandler discountHandler = new DiscountHandler();
            OrderHandler taxHandler = new TaxCalculationHandler();
            OrderHandler shippingHandler = new ShippingHandler();
            OrderHandler notificationHandler = new NotificationHandler();

            validationHandler.SetNext(discountHandler)
                             .SetNext(taxHandler)
                             .SetNext(shippingHandler)
                             .SetNext(notificationHandler);

            validationHandler.Handle(order);
        }
    }
}