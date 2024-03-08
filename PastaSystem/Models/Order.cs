namespace PastaSystem.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
    }
}
