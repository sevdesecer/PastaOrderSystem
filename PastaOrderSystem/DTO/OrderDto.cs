namespace WebApi.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public required string CustomerName { get; set; }
        public required string CustomerAddress { get; set; }
        public int? TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
        public List<PastaDto>? Pastas { get; set; }
        public List<BeverageDto>? Beverages { get; set; }
    }
}
