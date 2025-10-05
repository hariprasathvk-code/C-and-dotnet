using System;
namespace StrategyPatternD
{
    // Step 1: Strategy Interface
    interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    // Step 2: Concrete Strategies
    class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using Credit Card.");
        }
    }

    class PayPalPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using PayPal.");
        }
    }

    class UPIPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ₹{amount} using UPI.");
        }
    }

    // Step 3: Context class
    class ShoppingCart
    {
        private IPaymentStrategy _paymentStrategy;

        // Set strategy dynamically
        public void SetPaymentMethod(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Execute payment
        public void Checkout(double amount)
        {
            if (_paymentStrategy == null)
            {
                Console.WriteLine("⚠️ No payment method selected!");
                return;
            }

            _paymentStrategy.Pay(amount);
        }
    }

    // Step 4: Main Program
    class Program
    {
        static void Main()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.SetPaymentMethod(new CreditCardPayment());
            cart.Checkout(1500);

            cart.SetPaymentMethod(new PayPalPayment());
            cart.Checkout(2000);

            cart.SetPaymentMethod(new UPIPayment());
            cart.Checkout(500);
        }
    }
}
