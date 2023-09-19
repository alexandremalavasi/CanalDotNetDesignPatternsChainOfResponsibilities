using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanalDotNetDesignPatternsChainOfResponsibilities
{
    public class ValidationHandler : OrderHandler
    {
        public override void Handle(Order order)
        {
            if (IsValid(order))
            {
                Console.WriteLine("Order passed validation.");
                if (_nextHandler != null) _nextHandler.Handle(order);
            }
            else
            {
                Console.WriteLine("Order failed validation. Process terminated.");
            }
        }

        private bool IsValid(Order order)
        {
            return true;
        }
    }
}
