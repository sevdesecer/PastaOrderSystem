namespace MVC.Models.Order
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
        public List<Pasta.Pasta>? Pastas { get; set; }
        public List<Beverage.Beverage>? Beverages { get; set; }
    }
}