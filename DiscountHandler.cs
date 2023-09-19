using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanalDotNetDesignPatternsChainOfResponsibilities
{
    public class DiscountHandler : OrderHandler
    {
        public override void Handle(Order order)
        {
            if (ApplyDiscount(order))
            {
                Console.WriteLine("Discount applied.");
                if (_nextHandler != null) _nextHandler.Handle(order);
            }
            else
            {
                Console.WriteLine("No applicable discounts.");
                if (_nextHandler != null) _nextHandler.Handle(order);
            }

        }

        private bool ApplyDiscount(Order order)
        {
            if(order.PromoCode == "CANALDOTNET10")
            {
                order.TotalAmount = order.TotalAmount * 0.9m;
            }
            
            // Logic to apply discounts.
            return false; // example: no discount applied.
        }
    }
}
