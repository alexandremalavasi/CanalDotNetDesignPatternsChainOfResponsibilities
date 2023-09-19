using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanalDotNetDesignPatternsChainOfResponsibilities
{
    public class ShippingHandler : OrderHandler
    {
        public override void Handle(Order order)
        {
            string shippingMethod = DetermineShippingMethod(order);
            Console.WriteLine($"Shipping method determined: {shippingMethod}.");

            if (_nextHandler != null) _nextHandler.Handle(order);
        }

        private string DetermineShippingMethod(Order order)
        {
            if (order.Items.Count > 5 || order.TotalAmount > 500)
                return "Express Shipping";
            else
                return "Standard Shipping";
        }
    }

}
