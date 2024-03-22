namespace MVC.Models.Order  
{
    public class Order
    {
        public required string CustomerName { get; set; }
        public required string CustomerAddress { get; set; }
        public required int TotalPrice { get; set; }
        public required DateTime DateTime { get; set; }
        public List<Pasta.Pasta>? Pastas { get; set; }
        public List<Beverage.Beverage>? Beverage { get; set; }
    }
}
