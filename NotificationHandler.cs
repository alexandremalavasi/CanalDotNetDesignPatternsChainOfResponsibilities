using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanalDotNetDesignPatternsChainOfResponsibilities
{
    public class NotificationHandler : OrderHandler
    {
        public override void Handle(Order order)
        {
            NotifyUser(order);
        }

        private void NotifyUser(Order order)
        {
            Console.WriteLine($"Order processed. Total Amount: {order.TotalAmount}. Thank you for shopping with us!");
        }
    }

}
