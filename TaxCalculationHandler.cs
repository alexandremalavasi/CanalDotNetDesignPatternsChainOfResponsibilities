using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanalDotNetDesignPatternsChainOfResponsibilities
{
    public class TaxCalculationHandler : OrderHandler
    {
        public override void Handle(Order order)
        {
            decimal taxRate = GetTaxRate(order.UserLocation);
            decimal taxAmount = order.TotalAmount * taxRate;
            order.TotalAmount += taxAmount;

            Console.WriteLine($"Tax applied at rate {taxRate * 100}%. New total: {order.TotalAmount}.");

            if (_nextHandler != null) _nextHandler.Handle(order);

        }

        private decimal GetTaxRate(string location)
        {
            // In a real-world scenario, you'd probably look up the tax rate from a database or API.
            // For simplicity, we'll use hardcoded values.
            switch (location)
            {
                case "US":
                    return 0.07M; // 7% tax for US.
                case "EU":
                    return 0.20M; // 20% tax for EU.
                default:
                    return 0.05M; // 5% for other locations.
            }
        }
    }

}
