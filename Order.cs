namespace CanalDotNetDesignPatternsChainOfResponsibilities
{
    public class Order
    {
        public List<string> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string PromoCode { get; set; }
        public string UserLocation { get; set; }
    }
}
