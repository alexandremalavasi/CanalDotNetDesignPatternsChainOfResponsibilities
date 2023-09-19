namespace CanalDotNetDesignPatternsChainOfResponsibilities.BeforeDesignPattern
{
    public class Order
    {
        public List<string> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string PromoCode { get; set; }
        public string UserLocation { get; set; }
    }

    public class OrderProcessor
    {
        public void ProcessOrder(Order order)
        {
            // Validation
            if (!IsValid(order))
            {
                Console.WriteLine("Order failed validation. Process terminated.");
                return;
            }

            // Discount
            if (!ApplyDiscount(order))
            {
                Console.WriteLine("No applicable discounts.");
            }

            // Tax
            decimal taxRate;
            switch (order.UserLocation)
            {
                case "US":
                    taxRate = 0.07M;
                    break;
                case "EU":
                    taxRate = 0.20M;
                    break;
                default:
                    taxRate = 0.05M;
                    break;
            }
            order.TotalAmount += order.TotalAmount * taxRate;
            Console.WriteLine($"Tax applied at rate {taxRate * 100}%. New total: {order.TotalAmount}.");

            // Shipping
            string shippingMethod;
            if (order.Items.Count > 5 || order.TotalAmount > 500)
            {
                shippingMethod = "Express Shipping";
            }
            else
            {
                shippingMethod = "Standard Shipping";
            }
            Console.WriteLine($"Shipping method determined: {shippingMethod}.");

            // Notify User
            Console.WriteLine($"Order processed. Total Amount: {order.TotalAmount}. Thank you for shopping with us!");
        }

        private bool IsValid(Order order)
        {
            // Simplified validation logic
            return order.Items != null && order.Items.Count > 0;
        }

        private bool ApplyDiscount(Order order)
        {
            if (order.PromoCode == "INSIDER10")
            {
                order.TotalAmount -= 10;
                return true;
            }
            return false;
        }
    }

}
