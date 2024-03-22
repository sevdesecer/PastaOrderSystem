namespace MVC.Models.Beverage
{
    public class Beverage
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public required string ImagePath { get; set; }

    }
}
