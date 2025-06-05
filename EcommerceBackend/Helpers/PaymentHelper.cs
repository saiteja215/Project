namespace EcommerceBackend.Helpers
{
    public class PaymentHelper
    {
        public bool SimulatePayment()
        {
            // simulate payment success 80% of time
            return Random.Shared.Next(1, 101) <= 80;
        }
    }
}
